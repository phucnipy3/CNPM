using Common.Enums;
using GameEngine.GameComponents;
using GameEngine.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ClientTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //GameClient gameClient = new GameClient("127.0.0.1");
            //if (await gameClient.ConnectAsync())
            //{
            //    string message = await gameClient.ReceiveMessageAsync();
            //    Console.WriteLine(message);
            //    var x = JsonConvert.DeserializeObject<NetworkInformation>(message);
            //    if (await gameClient.SendMessageAsync(message))
            //    {
            //        Console.WriteLine("sucess");
            //    }
            //}
            //Console.ReadLine();

            CaroChessman[,] x = new CaroChessman[10,10];
        }
    }
}
