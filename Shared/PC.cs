using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using Thyrsus.Shared.Network;

namespace Thyrsus.Shared
{
    public class PC
    {
        public Socket Socket { get; set; }
        public Queue<IPacketOut> PacketQueue { get; set; }
        public string Ip { get; set; }

        protected readonly Network.Buffer buffer;
        protected Thread receiveThread;
        protected Thread senderThread;
        protected Thread parseThread;
        protected ManualResetEvent clientAbort;
        protected DateTime timeout;

        public PC()
        {
            clientAbort = new ManualResetEvent(false);
            PacketQueue = new Queue<IPacketOut>();

            // creating the buffer for the ragnarok packets
            buffer = new Network.Buffer();
        }

        public void Start()
        {
            receiveThread.Start();
            senderThread.Start();
            parseThread.Start();
        }

        public void Stop()
        {
            clientAbort.Set();
        }
    }
}
