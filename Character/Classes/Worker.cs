using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thyrsus.Shared;

namespace Thyrsus.Character.Classes
{
    public class Worker
    {
        public ManualResetEvent ServerShutdown;
        public static Worker Singleton;

        private const int port = 5001;
        private TcpListener listener;
        private List<ServiceHost> services;

        public Worker()
        {
            Worker.Singleton = this;
            ServerShutdown = new ManualResetEvent(false);
            Clients = new List<PC>();
            services = new List<ServiceHost>();
            StartListener(typeof(Inter));
        }

        public List<PC> Clients { get; set; }
        public List<Serverinformation> Serverlist { get; set; }

        public void Start()
        {
            Thread th = new Thread(WorkerThread);
            th.Start();
        }

        public void Stop()
        {
            ServerShutdown.Set();
            foreach (var svc in services)
            {
                if (svc.State == CommunicationState.Opened)
                {
                    svc.Close();
                }
            }
        }

        public void WorkerThread()
        {
            using (var account = new Account.AccountClient())
            {
                account.RegisterServer(Config.Sid, "127.0.0.1", port, "Chaos", Account.ServerTypes.Character);
            }

            this.listener = new TcpListener(new IPEndPoint(System.Net.IPAddress.Any, port));
            this.listener.Start();
            do
            {
                while (this.listener.Pending() == false)
                {
                    if (ServerShutdown.WaitOne(10)) return;
                }
                PC pc = new PC() { Socket = this.listener.AcceptSocket() };
                Thread th = new Thread(pc.Start);
                th.Start();
            } while (true);
        }

        private void StartListener(Type type)
        {
            try
            {
                var svc = new ServiceHost(type);
                svc.Open();
                foreach (var ep in svc.Description.Endpoints)
                {
                    Logging.Debug(string.Format("Listening at {0}", ep.Address.Uri));
                }

                services.Add(svc);
            }
            catch (Exception ex)
            {
                Logging.CriticalLog(ex.Message);
            }
        }
    }
}
