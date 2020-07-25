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
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(new MessageModel { Code = (int)MessageCode.Success}));
                    break;

                case (int)MessageCode.GetRooms:
                    int gameId;
                    if (int.TryParse(messageModel.Data.ToString(), out gameId))
                    {
                        ConsoleLog(client.User.Name + " get rooms");
                        messageModel.Data = await BLRoom.GetRoomsAsync(gameId);
                    }
                    else messageModel.Data = null;

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
                    messageModel.Data = await BLUser.ManagerUserAsync(int.Parse(messageModel.Data.ToString()));
                    await client.ReceivingClient.SendMessageAsync(JsonConvert.SerializeObject(messageModel));
                    break;
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
