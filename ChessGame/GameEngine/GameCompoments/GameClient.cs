using Common.Constants;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameComponents
{
    public class GameClient : NetworkComponent
    {
        public GameClient(string ip, int port = NetworkConstant.PORT) : base(ip, port)
        {
            client = new TcpClient();
        }

        public async Task<bool> ConnectAsync()
        {
            try
            {
                await client.ConnectAsync(ip, port);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
