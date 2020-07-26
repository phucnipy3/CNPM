using Common.Constants;
using Common.Enums;
using Common.Extensions;
using Common.FormInterfaces;
using Common.Logger;
using Common.Models;
using Communication.Client;
using Communication.Common;
using Data.Common;
using Data.Entities;
using GameEngine.Client;
using GameEngine.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helper.Client
{
    public class ClientHelper
    {
        public static string IP { get; set; } = "127.0.0.1";
        public static UserOnClientSide Client { get; private set; }
        public static CaroClient GameClient { get; private set; }


        public static async Task<UserModel> LoginAsync(string username, string password)
        {
            try
            {
                TcpClient sendingClient = new TcpClient();
                await sendingClient.ConnectAsync(IPAddress.Parse(IP), NetworkConstant.CLIENT_SENDING_PORT);

                LoginModel loginModel = new LoginModel() { Username = username, Password = password };
                await sendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Login, Data = loginModel }));

                var messageLogin = JsonConvert.DeserializeObject<MessageModel>(await sendingClient.ReceiveMessageAsync());
                if (messageLogin.Data == null)
                    return null;

                var userLogin = JsonConvert.DeserializeObject<UserModel>(messageLogin.Data.ToString());

                TcpClient receivingClient = new TcpClient();
                await receivingClient.ConnectAsync(IPAddress.Parse(IP), NetworkConstant.CLIENT_RECEIVING_PORT);
                await receivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Login, Data = userLogin.Id }));

                var data = JsonConvert.DeserializeObject<MessageModel>(await receivingClient.ReceiveMessageAsync());

                if (data.Code == (int)MessageCode.Success)
                {
                    Client = new UserOnClientSide(sendingClient, receivingClient);
                    Client.User = userLogin;
                    Client.MessageReceived += User_MessageReceivedAsync;
                    Client.Disconnected += Client_Disconnected;
                    return userLogin;
                }
                return null;
            }
            catch (Exception ex)
            {
                _ = Logger<ClientHelper>.LogAsync(ex.Message);
                return null;
            }
        }

        private static void Client_Disconnected(object sender, EventArgs e)
        {
            MessageBox.Show("Mất kết nối đến máy chủ!", "Thông báo");
            Application.Exit();
        }

        private static async void User_MessageReceivedAsync(object sender, MessageReceivedEventArgs e)
        {
            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(e.Message);
            switch (messageModel.Code)
            {
                case (int)MessageCode.RefreshRooms:
                    var frmRooms = Find("frmPickGame") as IPickGameForm;
                    if (frmRooms != null)
                        frmRooms.RefreshRooms();
                    break;

                case (int)MessageCode.RefreshCurrentRoom:
                    var frmCurrentRoom = Find("frmPlayGame") as IPlayGameForm;
                    if (frmCurrentRoom != null)
                        frmCurrentRoom.RefreshCurrentRoom(JsonConvert.DeserializeObject<RoomInfomationModel>(messageModel.Data.ToString()));
                    break;
                case (int)MessageCode.CaroMove:
                    try
                    {
                        GameClient.MakeOpponentMove(JsonConvert.DeserializeObject<CaroMove>(messageModel.Data.ToString()));
                    }
                    catch (InvalidOperationException)
                    {
                        await SendingMessageAsync((int)MessageCode.InvalidMove, null);
                    }
                    break;
                case (int)MessageCode.InvalidMove:
                    // Popup message
                    break;
            }
        }

        public static async Task SendingMessageAsync(int code, object dataModel)
        {
            string message = JsonConvert.SerializeObject(new MessageModel() { Code = code, Data = dataModel });
            await Client.SendingClient.SendMessageAsync(message);
        }

        public static async Task<UserModel> RegisterAsync(string username, string password)
        {
            try
            {
                TcpClient sendingClient = new TcpClient();
                await sendingClient.ConnectAsync(IPAddress.Parse(IP), NetworkConstant.CLIENT_SENDING_PORT);

                RegisterModel registerModel = new RegisterModel() { Username = username, Password = password };
                await sendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Register, Data = registerModel }));

                var messageRegister = JsonConvert.DeserializeObject<MessageModel>(await sendingClient.ReceiveMessageAsync());

                if (messageRegister.Code == (int)MessageCode.Success)
                {
                    return await LoginAsync(username, password);
                }
                return null;
            }
            catch (Exception ex)
            {
                _ = Logger<ClientHelper>.LogAsync(ex.Message);
                return null;
            }
        }

        public static async Task LogoutAsync()
        {
            if (Client != null)
            {
                await SendingMessageAsync((int)MessageCode.Logout, Client.User.Id);
                Client = null;
            }
        }

        public static async Task<MessageModel> ForceLogout(string id)
        {
            await SendingMessageAsync((int)MessageCode.ForceLogout, id);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel == null)
                messageModel = new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi không xác định" };
            return messageModel;
        }

        public static async Task<string> ForgetPasswordAsync(string username)
        {
            try
            {
                TcpClient sendingClient = new TcpClient();
                await sendingClient.ConnectAsync(IPAddress.Parse(IP), NetworkConstant.CLIENT_SENDING_PORT);

                await sendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.ForgetPassword, Data = username }));

                var message = JsonConvert.DeserializeObject<MessageModel>(await sendingClient.ReceiveMessageAsync());

                if (message != null)
                {
                    return message.Data.ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                _ = Logger<ClientHelper>.LogAsync(ex.Message);
                return null;
            }
        }

        public static async Task<MessageModel> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            ChangePasswordModel forgetPasswordModel = new ChangePasswordModel() { UserId = Client.User.Id, OldPassword = oldPassword, NewPassword = newPassword };
            await SendingMessageAsync((int)MessageCode.ChangePassword, forgetPasswordModel);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel == null)
                messageModel = new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi không xác định" };
            return messageModel;
        }

        public static async Task<MessageModel> UpdateProfileAsync(UserModel userModel)
        {
            await SendingMessageAsync((int)MessageCode.UpdateProfile, userModel);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel == null)
                messageModel = new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi không xác định" };
            return messageModel;
        }

        public static async Task<List<GameModel>> GetGameGuideAsync()
        {
            await SendingMessageAsync((int)MessageCode.GameGuide, null);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<GameModel>();

            return JsonConvert.DeserializeObject<List<GameModel>>(messageModel.Data.ToString());
        }

        public static async Task<List<Friend>>GetListFriendAsync()
        {
            await SendingMessageAsync((int)MessageCode.GetListFriend, Client.User.Id);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<Friend>();

            return JsonConvert.DeserializeObject<List<Friend>>(messageModel.Data.ToString());
        }

        public static async Task<List<RoomInfomationModel>> GetRoomsAsync(int gameId, string search)
        {
            await SendingMessageAsync((int)MessageCode.GetRooms, new RoomRequestModel() { GameId = gameId, Search = search });

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<RoomInfomationModel>();

            return JsonConvert.DeserializeObject<List<RoomInfomationModel>>(messageModel.Data.ToString());
        }

        public static async Task<MessageModel> DeleteFriendshipAsync(int friendId)
        {
            await SendingMessageAsync((int)MessageCode.DeleteFriendship, new FriendshipModel { UserId = Client.User.Id, FriendId = friendId});

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel == null)
                messageModel = new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi không xác định" };
            return messageModel;
        }
        public static async Task<List<GameModel>> GetGameAsync()
        {
            await SendingMessageAsync((int)MessageCode.GetGame, null);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<GameModel>();

            return JsonConvert.DeserializeObject<List<GameModel>>(messageModel.Data.ToString());
        }

        public static async Task<List<RankTable>> GetRankAsync(RankConditionModel rankCondition)
        {
            await SendingMessageAsync((int)MessageCode.GetRank, rankCondition);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<RankTable>();

            return JsonConvert.DeserializeObject<List<RankTable>>(messageModel.Data.ToString());
        }

        public static async Task<MessageModel> AddFeedbackAsync(Feedback feedback)
        {
            await SendingMessageAsync((int)MessageCode.AddFeedback, feedback);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel == null)
                messageModel = new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi không xác định" };
            return messageModel;
        }

        public static async Task<List<ManagerUser>> GetManagerUserAsync()
        {
            await SendingMessageAsync((int)MessageCode.ManageUser, null);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<ManagerUser>();

            return JsonConvert.DeserializeObject<List<ManagerUser>>(messageModel.Data.ToString());
        }

        public static async Task<MessageModel> ChangeStatusAsync(string userName, bool status)
        {
            ChangeStatusModel changeStatus = new ChangeStatusModel() { UserName = userName, Status = status };
            await SendingMessageAsync((int)MessageCode.ChangeStatus, changeStatus);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel == null)
                messageModel = new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi không xác định" };
            return messageModel;
        }

        public static async Task<List<UserModel>> GetAllManageUserAsync()
        {
            await SendingMessageAsync((int)MessageCode.GetAllUser, null);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<UserModel>();

            return JsonConvert.DeserializeObject<List<UserModel>>(messageModel.Data.ToString());
        }

        public static async Task<MessageModel> AddNotificationAsync(Notification notification)
        {
            await SendingMessageAsync((int)MessageCode.AddNotification, notification);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel == null)
                messageModel = new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi không xác định" };
            return messageModel;
        }

        public static async Task<List<FeedbackModel>> GetAllFeedbackAsync()
        {
            await SendingMessageAsync((int)MessageCode.GetFeedback, null);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<FeedbackModel>();

            return JsonConvert.DeserializeObject<List<FeedbackModel>>(messageModel.Data.ToString());
        }

        public static async Task<List<CheckFeedback>> CheckFeedbackAsync()
        {
            await SendingMessageAsync((int)MessageCode.CheckFeedback, null);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<CheckFeedback>();

            return JsonConvert.DeserializeObject<List<CheckFeedback>>(messageModel.Data.ToString());
        }

        public static async Task<MessageModel> AddMaintainAsync(MaintainceInfomation maintaince)
        {
            await SendingMessageAsync((int)MessageCode.Maintain, maintaince);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel == null)
                messageModel = new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi không xác định" };
            return messageModel;
        }

        public static async Task<RoomInfomationModel> CreateRoom(int gameId)
        {
            await SendingMessageAsync((int)MessageCode.CreateRoom, new RoomRequestModel() { UserId = Client.User.Id, GameId = gameId });

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return null;

            return JsonConvert.DeserializeObject<RoomInfomationModel>(messageModel.Data.ToString());
        }

        public static async Task<RoomInfomationModel> JoinRoom(int roomId)
        {
            await SendingMessageAsync((int)MessageCode.JoinRoom, new RoomRequestModel() { UserId = Client.User.Id, RoomId = roomId });

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return null;

            return JsonConvert.DeserializeObject<RoomInfomationModel>(messageModel.Data.ToString());
        }

        private static Form Find(string frmName)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == frmName)
                {
                    return frm;
                }
            }
            return null;
        }

        public static void MakeMove(Point mouseLocation, Cursor cur)
        {
            int mouseXOffset = -cur.Size.Width / 2;
            int mouseYOffset = cur.Size.Height / 2;
            int x = (mouseLocation.X + mouseXOffset) / GameClient.CellSize;
            int y = (mouseLocation.Y + mouseYOffset) / GameClient.CellSize;

            GameClient.MakeOwnMove(x, y);
        }

    }
}
