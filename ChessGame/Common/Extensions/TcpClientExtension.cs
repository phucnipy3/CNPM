using Common.Constants;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class TcpClientExtension
    {
        public static async Task<bool> SendMessageAsync(this TcpClient client, string message)
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

        public static async Task<string> ReceiveMessageAsync(this TcpClient client)
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
