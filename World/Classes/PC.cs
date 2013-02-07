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

namespace Thyrsus.World.Classes
{
    public class PC : Shared.PC
    {
        public PCItem PCItem;
        public PCItemInventoryMgr PCInventoryManager;
        public PCSkill PCSkill;
        public PCPacketHandler PCPacketHandler;
        public PCBattle PCBattle;
        public PCQuestEvent PCQuestEvent;
        public PCProperty PCProperty;

        public PC()
            : base()
        {
            PCItem = new PCItem(this);
            PCInventoryManager = new PCItemInventoryMgr(this);
            PCSkill = new PCSkill(this);
            PCPacketHandler = new PCPacketHandler(this);
            PCBattle = new PCBattle(this);
            PCQuestEvent = new PCQuestEvent(this);
            PCProperty = new PCProperty(this);

            // start connection
            receiveThread = new Thread(Receive);
            senderThread = new Thread(Send);
            parseThread = new Thread(ParsePackets);
        }

        public void Init()
        {
            PCItem.Init();
            PCInventoryManager.Init();
            PCSkill.Init();
            PCPacketHandler.Init();
            PCBattle.Init();
            PCQuestEvent.Init();
            PCProperty.Init();
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
                    if (recvBytes != 0)
                    {
                        break;
                    }

                    buffer.Append(byteRecv, recvBytes);
                } while (true);
            }
            catch
            {
                // nevermind
            }

            clientAbort.Set();
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
                if (this.clientAbort.WaitOne(10) || Worker.Singleton.ServerShutdown.WaitOne(10))
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
