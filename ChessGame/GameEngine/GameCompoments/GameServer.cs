using Common.Constants;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameComponents
{
    public class GameServer : NetworkComponent
    {
        private TcpListener server;

        public GameServer(string ip, int port = NetworkConstant.PORT) : base(ip, port)
        {
            server = new TcpListener(this.ip, port);
        }

        public async Task<bool> ListenAsync()
        {
            try
            {
                server.Start();

                client = await server.AcceptTcpClientAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
