using Common.Constants;
using Common.Enums;
using Common.Extensions;
using Common.Logger;
using Common.Models;
using Communication.Client;
using Communication.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Helper.Client
{
    public class ClientHelper
    {
        public static string IP { get; set; } = "127.0.0.1";
        public static UserOnClientSide Client { get; private set; }

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
                    Client.MessageReceived += User_MessageReceived;
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

        private static void User_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(e.Message);
            switch (messageModel.Code)
            {
                case (int)MessageCode.Success: break;
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

        public static async Task<List<GameModel>> GameGuideAsync()
        {
            await SendingMessageAsync((int)MessageCode.GameGuide, null);

            MessageModel messageModel = JsonConvert.DeserializeObject<MessageModel>(await Client.SendingClient.ReceiveMessageAsync());
            if (messageModel.Data == null)
                return new List<GameModel>();

            return JsonConvert.DeserializeObject<List<GameModel>>(messageModel.Data.ToString());
        }
    }
}
