using Common.Constants;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameComponents
{
    public class NetworkComponent
    {
        protected IPAddress ip;
        protected int port;
        protected TcpClient client;

        public NetworkComponent(string ip, int port = NetworkConstant.PORT)
        {
            this.ip = IPAddress.Parse(ip);
            this.port = port;
        }

        public async Task<bool> SendMessageAsync(string message)
        {
            try
            {
                message = message + NetworkConstant.MESSAGE_KEY;
                byte[] buffer = new byte[NetworkConstant.BUFFER_MAX_LENGTH];
                Encoding.UTF8.GetBytes(message, 0, message.Length, buffer, 0);

                NetworkStream networkStream = client.GetStream();
                await networkStream.WriteAsync(buffer, 0, buffer.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> ReceiveMessageAsync()
        {
            try
            {
                byte[] buffer = new byte[NetworkConstant.BUFFER_MAX_LENGTH];


                NetworkStream networkStream = client.GetStream();
                await networkStream.ReadAsync(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer);
                return message.Substring(0, message.LastIndexOf(NetworkConstant.MESSAGE_KEY));
            }
            catch
            {
                return null;
            }
        }
    }
}
