using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thyrsus.Account.Classes
{
    public class Worker
    {
        private const int port = 6900;
        private TcpListener listener;

        public ManualResetEvent ServerShutdown;
        public static Worker Singleton;

        public Worker()
        {
            ServerShutdown = new ManualResetEvent(false);
            Worker.Singleton = this;
        }

        public void Start()
        {
            this.listener = new TcpListener(new IPEndPoint(System.Net.IPAddress.Any, port));
            this.listener.Start();
            do
            {
                while (this.listener.Pending() == false)
                {
                    try
                    {
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {                        
                        throw;
                    }
                }
                PCHandler pc = new PCHandler() { Socket = this.listener.AcceptSocket() };
                Thread th = new Thread(pc.Start);
                th.Start();
            } while (1 == 1);
        }
    }
}
