using Communication.Common;
using System.Net.Sockets;

namespace Communication.Client
{
    public class UserOnClientSide : UserCommunication
    {
        public UserOnClientSide(TcpClient sendingClient, TcpClient receivingClient) : base(receivingClient)
        {
            SendingClient = sendingClient;
        }
    }
}
