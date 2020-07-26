using Common.Constants;
using Common.Enums;
using Common.Extensions;
using Common.Logger;
using Common.Models;
using Common.SendMail;
using Communication.Common;
using Communication.Server;
using Data.BusinessLogic;
using Data.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class CommunicationServer
    {
        private CommunicationComponent sendingComponent;
        private CommunicationComponent receivingComponent;
        private List<UserOnServerSide> users;

        public CommunicationServer(string ip)
        {
            users = new List<UserOnServerSide>();
            sendingComponent = new CommunicationComponent(ip, NetworkConstant.SERVER_SENDING_PORT);
            sendingComponent.NewClientAccepted += SendingComponent_NewClientAccepted;
            _ = sendingComponent.StartListenAsync();
            receivingComponent = new CommunicationComponent(ip, NetworkConstant.SERVER_RECEIVING_PORT);
            receivingComponent.NewClientAccepted += ReceivingComponent_NewClientAccepted;
            _ = receivingComponent.StartListenAsync();
        }

        private async void ReceivingComponent_NewClientAccepted(object sender, NewClientAcceptedEventArgs e)
        {
            var message = JsonConvert.DeserializeObject<MessageModel>(await e.Client.ReceiveMessageAsync());

            switch (message.Code)
            {
                case (int)MessageCode.Login:
                    LoginModel loginModel = JsonConvert.DeserializeObject<LoginModel>(message.Data.ToString());

                    var userModel = await new BLUser().LoginAsync(loginModel.Username, loginModel.Password);
                    await e.Client.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Login, Data = userModel }));

                    if (userModel != null)
                    {
                        users.Add(new UserOnServerSide(userModel, e.Client));
                        users.Last().MessageReceived += CommunicationServer_MessageReceivedAsync;
                        await new BLUser().ChangeActiveAsync(userModel.Id, true);
                    }
                    break;

                case (int)MessageCode.Register:
                    RegisterModel registerModel = JsonConvert.DeserializeObject<RegisterModel>(message.Data.ToString());

                    if (await new BLUser().Exists(registerModel.Username))
                        await e.Client.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Error, Data = "Tên tài khoản đã tồn tại!" }));
                    else
                    {
                        await new BLUser().SignupAsync(registerModel);
                        await e.Client.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Success }));
                    }
                    ConsoleLog(registerModel.Username + " register account");
                    break;

                case (int)MessageCode.ForgetPassword:
                    string username = message.Data.ToString();
                    string email = await new BLUser().GetEmailByUsernameAsync(username);
                    string info;

                    if (!string.IsNullOrEmpty(email))
                    {
                        string password = RandomString(8);
                        if (await SendEmail.SendEmailAsync(email, password.ToString()))
                        {
                            await new BLUser().ChangePasswordAsync(username, password);
                            info = "Kiểm tra mail để lấy lại mật khẩu!";
                        }
                        else info = "Server quá tải hoặc đang bảo trì!";
                    }
                    else info = "Tài khoản không tồn tại hoặc không có thông tin email!";

                    ConsoleLog(username + " request forget password");
                    await e.Client.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Success, Data = info }));
                    break;
            }
        }

        private async void SendingComponent_NewClientAccepted(object sender, NewClientAcceptedEventArgs e)
        {
            var message = JsonConvert.DeserializeObject<MessageModel>(await e.Client.ReceiveMessageAsync());
            int Id;
            if (message.Code == (int)MessageCode.Login && int.TryParse(message.Data.ToString(), out Id))
            {
                var player = users.Where(x => x.User.Id == Id).FirstOrDefault();
                if (player != null)
                {
                    player.SendingClient = e.Client;
                    ConsoleLog(player.User.Name + " login");
                    await e.Client.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Success }));
                    return;
                }
            }
            await e.Client.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Error, Data = "Lỗi" }));

        }

        private async void CommunicationServer_MessageReceivedAsync(object sender, MessageReceivedEventArgs e)
        {
            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(e.Message);
            var client = sender as UserOnServerSide;

            switch (messageModel.Code)
            {
                case (int)MessageCode.Logout: await LogoutAsync(messageModel.Data); break;

                case (int)MessageCode.ChangePassword:
                    ConsoleLog(client.User.Name + " change password");
                    var changePasswordModel = JsonConvert.DeserializeObject<ChangePasswordModel>(messageModel.Data.ToString());
                    messageModel = await new BLUser().ChangePassword(changePasswordModel);
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;

                case (int)MessageCode.UpdateProfile:
                    ConsoleLog(client.User.Name + " update profile");
                    var userModel = JsonConvert.DeserializeObject<UserModel>(messageModel.Data.ToString());
                    messageModel = await new BLUser().UpdateProfile(userModel);
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;

                case (int)MessageCode.GameGuide:
                    ConsoleLog(client.User.Name + " get game guide");
                    messageModel.Data = await new BLGame().GetGamesAsync();
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
                case (int)MessageCode.GetListFriend:
                    int id;
                    if (int.TryParse(messageModel.Data.ToString(), out id))
                    {
                        ConsoleLog(client.User.Name + " get list friend");
                        messageModel.Data = await new BLFriend().GetFriendByUserNameAsync(id);
                    }
                    else
                    {
                        messageModel.Data = null;
                    }
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;

                case (int)MessageCode.DeleteFriendship:
                    ConsoleLog(client.User.Name + " delete friend");
                    await new BLFriend().DeleteFriendAsync(JsonConvert.DeserializeObject<FriendshipModel>(messageModel.Data.ToString()));
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = (int)MessageCode.Success }));
                    break;

                case (int)MessageCode.GetRooms:
                    var getRoomModel = JsonConvert.DeserializeObject<RoomRequestModel>(messageModel.Data.ToString());

                    messageModel.Data = await BLRoom.GetRoomsAsync(getRoomModel.GameId, getRoomModel.Search);
                    ConsoleLog(client.User.Name + " get rooms");

                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;

                case (int)MessageCode.CreateRoom:
                    var createRoomModel = JsonConvert.DeserializeObject<RoomRequestModel>(messageModel.Data.ToString());

                    messageModel.Data = await BLRoom.CreateRoom(createRoomModel.UserId, createRoomModel.GameId);
                    ConsoleLog(client.User.Name + " create rooms");

                    _ = SendingAllUserAsync(new MessageModel() { Code = (int)MessageCode.RefreshRooms });

                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;

                case (int)MessageCode.JoinRoom:
                    var joinRoomModel = JsonConvert.DeserializeObject<RoomRequestModel>(messageModel.Data.ToString());

                    var roomInfo = await BLRoom.JoinRoom(joinRoomModel.UserId, joinRoomModel.RoomId);
                    messageModel.Data = roomInfo;
                    ConsoleLog(client.User.Name + " join rooms");

                    UserOnServerSide opponent;
                    if (roomInfo.Count == 2)
                    {
                        if (roomInfo.FirstPlayer.Id == joinRoomModel.UserId)
                            opponent = users.Where(x => x.User.Id == roomInfo.SecondPlayer.Id).FirstOrDefault();
                        else opponent = users.Where(x => x.User.Id == roomInfo.FirstPlayer.Id).FirstOrDefault();

                        await opponent.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.RefreshCurrentRoom, Data = roomInfo }));
                    }

                    _ = SendingAllUserAsync(new MessageModel() { Code = (int)MessageCode.RefreshRooms });

                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
                case (int)MessageCode.GetGame:
                    ConsoleLog(client.User.Name + " get game");
                    messageModel.Data = await new BLGame().GetGamesAsync();
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
                case (int)MessageCode.GetRank:
                    ConsoleLog(client.User.Name + " get rank ");
                    messageModel.Data = await BLElo.GetRankTableAsync(JsonConvert.DeserializeObject<RankConditionModel>(messageModel.Data.ToString()));
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
                case (int)MessageCode.AddFeedback:
                    ConsoleLog(client.User.Name + " Add feedback");
                    await BLFeedback.AddFeedbackAsync(JsonConvert.DeserializeObject<Feedback>(messageModel.Data.ToString()));
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = (int)MessageCode.Success }));
                    break;
                case (int)MessageCode.ManageUser:
                    ConsoleLog(client.User.Name + " manage users ");
                    messageModel.Data = await BLUser.ManagerUserAsync();
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
                case (int)MessageCode.ChangeStatus:
                    ConsoleLog(client.User.Name + " change status user");
                    var changeStatus = JsonConvert.DeserializeObject<ChangeStatusModel>(messageModel.Data.ToString());
                    bool hasChangeStatus = await BLUser.ChangeStatusAsync(changeStatus.UserName, changeStatus.Status);
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = hasChangeStatus ? (int)MessageCode.Success : (int)MessageCode.Error }));
                    break;
                case (int)MessageCode.GetAllUser:
                    ConsoleLog(client.User.Name + " get all user");
                    messageModel.Data = await BLUser.GetAllManageUserAsync();
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
                case (int)MessageCode.AddNotification:
                    ConsoleLog(client.User.Name + " add notification");
                    await BLNotification.AddNotificationAsync(JsonConvert.DeserializeObject<Notification>(messageModel.Data.ToString()));
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = (int)MessageCode.Success }));
                    break;
                case (int)MessageCode.GetFeedback:
                    ConsoleLog(client.User.Name + " get all feedback");
                    messageModel.Data = await BLFeedback.GetAllFeedbackAsync();
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
                case (int)MessageCode.CheckFeedback:
                    ConsoleLog(client.User.Name + " check feedback");
                    messageModel.Data = await BLFeedback.CheckFeedbackAsync();
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
                case (int)MessageCode.Maintain:
                    ConsoleLog(client.User.Name + " add maintaince information");
                    await BLMaintaince.AddMaintainceAsync(JsonConvert.DeserializeObject<MaintainceInfomation>(messageModel.Data.ToString()));
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = (int)MessageCode.Success }));
                    break;
                case (int)MessageCode.ForceLogout:
                    ConsoleLog(client.User.Name + " send request force logout");
                    bool hasForceLogout = await ForceLogoutAsync(messageModel.Data);
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = hasForceLogout ? (int)MessageCode.Success : (int)MessageCode.Error }));
                    break;
                case (int)MessageCode.AddFriend:
                    ConsoleLog(client.User.Name + " send request add friend");
                    string messageAddFriend = await CheckAddFriendAsync(messageModel.Data);
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = String.IsNullOrEmpty(messageAddFriend) ? (int)MessageCode.Success : (int)MessageCode.Error, Data = messageAddFriend }));
                    break;
                case (int)MessageCode.ReplyAddFriend:
                    ConsoleLog(client.User.Name + " reply add friend");
                    string messageReplyAddFriend = await ReplyAddFriendAsync(messageModel.Data);
                    if (!string.IsNullOrEmpty(messageReplyAddFriend))
                    {
                        messageModel.Data = messageReplyAddFriend;
                        await client.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    }
                    break;
                case (int)MessageCode.InvitePlay:
                    ConsoleLog(client.User.Name + " send request invite play");
                    string messageInvitePlay = await CheckInvitePlayAsync(messageModel.Data);
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = String.IsNullOrEmpty(messageInvitePlay) ? (int)MessageCode.Success : (int)MessageCode.Error, Data = messageInvitePlay }));
                    break;
                case (int)MessageCode.ReplyInvitePlay:
                    ConsoleLog(client.User.Name + " reply invite play");
                    string messageReplyInvitePlay = await ReplyInvitePlayAsync(messageModel.Data);
                    if (!string.IsNullOrEmpty(messageReplyInvitePlay))
                    {
                        messageModel.Data = messageReplyInvitePlay;
                        await client.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    }
                    break;
                case (int)MessageCode.SendMessage:
                    ConsoleLog(client.User.Name + " send message");
                    /////////////////////////////////////////
                    string addMessage = await BLMesssage.AddMessageAsync(JsonConvert.DeserializeObject<SendMessageModel>(messageModel.Data.ToString()));
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = addMessage ? (int)MessageCode.Success : (int)MessageCode.Error}));
                    break;
            }
        }

        

        private async Task<string> ReplyInvitePlayAsync(object data)
        {
            var messageModel = JsonConvert.DeserializeObject<MessageModel>(data.ToString());
            var invitePlayModel = JsonConvert.DeserializeObject<InvitePlayModel>(messageModel.Data.ToString());

            var user = users.FirstOrDefault(x => x.User.Username == invitePlayModel.UserName);
            var opponent = users.FirstOrDefault(x => x.User.Username == invitePlayModel.OpponentName);
            if (user == null)
                return "Bạn của bạn đã ngoại tuyến!";

            if (messageModel.Code == (int)MessageCode.Error)
            {
                await user.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.ReplyInvitePlay, Data = invitePlayModel.OpponentName + " đã từ chối lời mời chơi từ bạn!" }));
                return null;
            }

            string message = "Lỗi không xác định";
            var roomInfo = await BLRoom.CreateRoom(user.User.Id, 1);
            if (roomInfo != null)
            {
                invitePlayModel.RoomId = roomInfo.RoomId;
                var roomInfoInvite = await BLRoom.JoinRoom(opponent.User.Id, invitePlayModel.RoomId);
                return "Vào phòng " + invitePlayModel.RoomId.ToString();
            }

            await user.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.ReplyInvitePlay, Data = message }));
            return message;
        }

        private async Task<string> CheckInvitePlayAsync(object data)
        {
            var model = JsonConvert.DeserializeObject<InvitePlayModel>(data.ToString());
            if (!await new BLUser().Exists(model.OpponentName))
                return "Tài khoản không tồn tại!";

            var friend = users.FirstOrDefault(x => x.User.Username == model.OpponentName);
            if (friend == null)
                return "Tài khoản hiện không hoạt động!";

            await friend.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.InvitePlay, Data = data }));
            return "";
        }

        private async Task<string> ReplyAddFriendAsync(object data)
        {
            var messageModel = JsonConvert.DeserializeObject<MessageModel>(data.ToString());
            var addFriendModel = JsonConvert.DeserializeObject<AddFriendModel>(messageModel.Data.ToString());

            var user = users.FirstOrDefault(x => x.User.Username == addFriendModel.UserName);
            if (user == null)
                return "Bạn của bạn đã ngoại tuyến!";

            if (messageModel.Code == (int)MessageCode.Error)
            {     
                await user.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.ReplyAddFriend, Data = addFriendModel.FriendName + " đã từ chối lời mời kết bạn!" }));
                return null;
            }

            string message = "Lỗi không xác định";
            if (await new BLUser().AddFriend(addFriendModel))
            {
                await user.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.ReplyAddFriend, Data = "Bạn và " + addFriendModel.FriendName + " đã trở thành bạn bè. Hiện có thể nhắn tin và chơi cùng nhau!" }));
                return "Bạn và " + addFriendModel.UserName + " đã trở thành bạn bè. Hiện có thể nhắn tin và chơi cùng nhau!";
            }

            await user.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.ReplyAddFriend, Data = message }));
            return message;
        }

        private async Task<string> CheckAddFriendAsync(object data)
        {
            var model = JsonConvert.DeserializeObject<AddFriendModel>(data.ToString());
            if (!await new BLUser().Exists(model.FriendName))
                return "Tài khoản không tồn tại!";

            var friend = users.FirstOrDefault(x => x.User.Username == model.FriendName);
            if (friend == null)
                return "Tài khoản hiện không hoạt động!";

            await friend.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.AddFriend, Data = data }));
            return "";
        }

        private async Task<bool> ForceLogoutAsync(object data)
        {
            int id;
            if (int.TryParse(data.ToString(), out id))
            {
                var user = users.FirstOrDefault(x => x.User.Id == id);
                if (user != null)
                {
                    await user.SendingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel() { Code = (int)MessageCode.Disconnected }));
                    users.Remove(user);
                    ConsoleLog(user.User.Name + " force logout");
                    await new BLUser().ChangeActiveAsync(id, false);
                    return true;
                }
            }
            return false;
        }

        private async Task SendingAllUserAsync(MessageModel message)
        {
            foreach (var user in users)
            {
                var str = JsonConvert.SerializeObject(message);
                await user.SendingClient.SendMessageAsync(str);
            }
        }

        private async Task LogoutAsync(object data)
        {
            int id;
            if (int.TryParse(data.ToString(), out id))
            {
                var user = users.FirstOrDefault(x => x.User.Id == id);
                if (user != null)
                {
                    users.Remove(user);
                    ConsoleLog(user.User.Name + " logout");
                    await new BLUser().ChangeActiveAsync(id, false);
                }
            }
        }

        private string RandomString(int lenght)
        {
            string res = "";
            System.Random random = new System.Random();
            while (lenght > 0)
            {
                char key = (char)random.Next(48, 123);
                if (Char.IsLetterOrDigit(key))
                {
                    res += key;
                    lenght--;
                }
            }
            return res;
        }

        private void ConsoleLog(string message)
        {
            string log = message + " at " + DateTime.Now;
            Console.WriteLine(log);
            _ = Logger<CommunicationServer>.LogAsync(log);
        }
    }
}
