using GameEngine.GameComponents;
using GameEngine.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ServerTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            GameServer gameServer = new GameServer("127.0.0.1");
            if (await gameServer.ListenAsync())
            {
                var x = new NetworkInformation() { Move = new Move() { X = 1, Y = 2 }, SenderWin = true };
                if (!await gameServer.SendMessageAsync(JsonConvert.SerializeObject(x)))
                    Console.WriteLine("fail");
                string message = await gameServer.ReceiveMessageAsync();
                Console.WriteLine(message);
            }
            Console.ReadLine();
        }
    }
}
