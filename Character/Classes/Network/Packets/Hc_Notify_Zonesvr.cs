using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;
using Thyrsus.Shared.Network;

namespace Thyrsus.Character.Classes.Network.Packets
{
    [Method((ushort)HEADER.HEADER_HC_NOTIFY_ZONESVR, "HC_NOTIFY_ZONESVR", MethodAttribute.Packetdirection.PdOut, 0)]
    public class Hc_Notify_Zonesvr : IPacketOut
    {
        private static readonly Hc_Notify_Zonesvr defaultInstance = new Hc_Notify_Zonesvr().MakeReadOnly();

        private Hc_Notify_Zonesvr MakeReadOnly()
        {
            return this;
        }

        public static Hc_Notify_Zonesvr DefaultInstance
        {
            get { return defaultInstance; }
        }

        public int Gid { get; private set; }
        public string Mapname { get; private set; }
        public ulong Ip { get; private set; }
        public int Port { get; private set; }

        public void WriteTo(BinaryWriter output)
        {
            output.Write(new byte[] { 0x71, 0x00 });
            output.Write(Gid);
            output.WriteCString(Mapname, 16);
            output.Write((uint)Ip);
            output.Write((short)Port);
        }

        public sealed partial class Builder
        {
            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private Hc_Notify_Zonesvr result;

            private Hc_Notify_Zonesvr PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    Hc_Notify_Zonesvr original = result;
                    result = new Hc_Notify_Zonesvr();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public Builder MergeFrom(Hc_Notify_Zonesvr other)
            {
                if (other == DefaultInstance) return this;
                PrepareBuilder();
                return this;
            }

            /*
             * Gid
             */
            public int Gid
            {
                get { return result.Gid; }
                set { SetGid(value); }
            }
            public Builder SetGid(int value)
            {
                PrepareBuilder();
                result.Gid = value;
                return this;
            }
            public Builder ClearGid()
            {
                PrepareBuilder();
                result.Gid = 0;
                return this;
            }

            /*
             * Mapname
             */
            public string Mapname
            {
                get { return result.Mapname; }
                set { SetMapname(value); }
            }
            public Builder SetMapname(string value)
            {
                PrepareBuilder();
                result.Mapname = value;
                return this;
            }
            public Builder ClearMapname()
            {
                PrepareBuilder();
                result.Mapname = "";
                return this;
            }

            /*
             * Ip
             */
            public ulong Ip
            {
                get { return result.Ip; }
                set { SetIp(value); }
            }
            public Builder SetIp(ulong value)
            {
                PrepareBuilder();
                result.Ip = value;
                return this;
            }
            public Builder ClearIp()
            {
                PrepareBuilder();
                result.Ip = 0;
                return this;
            }

            /*
             * Port
             */
            public int Port
            {
                get { return result.Port; }
                set { SetPort(value); }
            }
            public Builder SetPort(int value)
            {
                PrepareBuilder();
                result.Port = value;
                return this;
            }
            public Builder ClearPort()
            {
                PrepareBuilder();
                result.Port = 0;
                return this;
            }

            public Hc_Notify_Zonesvr Build()
            {
                return result;
            }
        }

        public static Builder CreateBuilder() { return new Builder(); }
    }
}
