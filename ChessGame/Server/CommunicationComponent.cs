using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    public class CommunicationComponent
    {
        private TcpListener listener;
        public event EventHandler<NewClientAcceptedEventArgs> NewClientAccepted;

        public CommunicationComponent(string ip, int port)
        {
            listener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public async Task StartListenAsync()
        {
            listener.Start();
            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                OnNewClientAccepted(new NewClientAcceptedEventArgs { Client = client });
            }
        }

        protected virtual void OnNewClientAccepted(NewClientAcceptedEventArgs e)
        {
            EventHandler<NewClientAcceptedEventArgs> handler = NewClientAccepted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class NewClientAcceptedEventArgs : EventArgs
    {
        public TcpClient Client { get; set; }
    }
}
