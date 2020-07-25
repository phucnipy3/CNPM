using Common.Extensions;
using Common.Models;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Communication.Common
{
    public class UserCommunication
    {
        public UserModel User { get; set; }
        public TcpClient SendingClient { get; set; }
        public TcpClient ReceivingClient { get; protected set; }
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public UserCommunication(TcpClient receivingClient)
        {
            ReceivingClient = receivingClient;
            _ = StartReceiveAsync();
        }

        public async Task StartReceiveAsync()
        {
            while (true)
            {
                string message = await ReceivingClient.ReceiveMessageAsync();
                if (!string.IsNullOrEmpty(message))
                    OnMessageReceived(new MessageReceivedEventArgs() { Message = message });
            }
        }

        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        {
            EventHandler<MessageReceivedEventArgs> handler = MessageReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
