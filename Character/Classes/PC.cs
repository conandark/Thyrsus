using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thyrsus.Shared;
using Thyrsus.Shared.Network;

namespace Thyrsus.Character.Classes
{
    public class PC : Shared.PC
    {
        public int Aid { get; set; }
        public GetCharInfoResult[] Characters;

        public PC()
            : base()
        {
            // start connection
            receiveThread = new Thread(Receive);
            senderThread = new Thread(Send);
            parseThread = new Thread(ParsePackets);
            timeout = DateTime.UtcNow;
        }

        public void Receive()
        {
            try
            {
                var byteRecv = new Byte[32769];
                do
                {
                    while (Socket.Available == 0)
                    {
                        if (this.timeout.AddSeconds(5) < DateTime.UtcNow)
                        {
                            Stop();
                        }
                        if (this.clientAbort.WaitOne(10) || Worker.Singleton.ServerShutdown.WaitOne(10))
                        {
                            return;
                        }
                    }

                    var recvBytes = Socket.Receive(byteRecv, SocketFlags.None);
                    this.timeout = DateTime.UtcNow;
                    if (recvBytes == 0)
                    {
                        return;
                    }

                    buffer.Append(byteRecv, recvBytes);
                } while (true);
            }
            finally
            {
                clientAbort.Set();
            }
        }

        private void Send()
        {
            try
            {
                while (Socket.Connected)
                {
                    if (this.clientAbort.WaitOne(10) || Worker.Singleton.ServerShutdown.WaitOne(10))
                    {
                        return;
                    }

                    while (PacketQueue.Count > 0)
                    {
                        var p = PacketQueue.Dequeue();
                        using (var ms = new MemoryStream())
                        {
                            using (var bw = new BinaryWriter(ms))
                            {
                                p.WriteTo(bw);
                                Logging.Debug(ms.ToArray().Hexdump());
                                Socket.Send(ms.ToArray());
                            }
                        }
                    }
                }
            }
            catch
            {
                // nevermind
            }

            this.clientAbort.Set();
        }

        private void ParsePackets()
        {
            while (Socket.Connected)
            {
                if (ManualResetEvent.WaitAny(new[] { this.clientAbort, Worker.Singleton.ServerShutdown }, 10) == 0)
                {
                    return;
                }

                while (this.buffer.PacketAvaliable())
                {
                    try
                    {
                        var packet = this.buffer.GetPacket();
                        this.buffer.Consume();

                        if (!Enum.IsDefined(typeof(HEADER), packet.Header.MethodId) &&
                            !Enum.IsDefined(typeof(SPECIAL_HEADER), packet.Header.MethodId))
                        {
                            this.buffer.Clear();
                        }

                        using (var ms = new MemoryStream(packet.Data))
                        {
                            using (var br = new BinaryReader(ms))
                            {
                                var mi = Method.GetById(packet.Header.MethodId);
                                if (mi != null)
                                {
                                    mi.Parse(this, packet);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logging.CriticalLog(ex.Message);
                        this.clientAbort.Set();
                    }
                }
            }
        }
    }
}
