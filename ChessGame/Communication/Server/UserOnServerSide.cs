using Common.Models;
using Communication.Common;
using System.Net.Sockets;

namespace Communication.Server
{
    public class UserOnServerSide : UserCommunication
    {
        public UserOnServerSide(UserModel user, TcpClient receivingClient) : base(receivingClient)
        {
            User = user;
        }
    }
}
