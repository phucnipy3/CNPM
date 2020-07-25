using System;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CommunicationServer server = new CommunicationServer("127.0.0.1");
            while (true)
            {
                Console.WriteLine("Application is running...");
                await Task.Delay(30000);
            }
        }
    }
}
