using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;
using Thyrsus.Shared.Network;

namespace Thyrsus.Account.Classes.Network.Packets
{
    [Method((ushort)HEADER.HEADER_SC_NOTIFY_BAN, "SC_NOTIFY_BAN", MethodAttribute.Packetdirection.PdOut, 0)]
    public class Sc_Notify_Ban : IPacketOut
    {
        private static readonly Sc_Notify_Ban defaultInstance = new Sc_Notify_Ban().MakeReadOnly();

        private Sc_Notify_Ban MakeReadOnly()
        {
            return this;
        }

        public static Sc_Notify_Ban DefaultInstance
        {
            get { return defaultInstance; }
        }

        public byte ErrorCode { get; private set; }

        public void WriteTo(BinaryWriter output)
        {
            output.Write((ushort)HEADER.HEADER_SC_NOTIFY_BAN);
            output.Write(ErrorCode);
        }

        public sealed partial class Builder
        {
            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private Sc_Notify_Ban result;

            private Sc_Notify_Ban PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    Sc_Notify_Ban original = result;
                    result = new Sc_Notify_Ban();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public Builder MergeFrom(Sc_Notify_Ban other)
            {
                if (other == DefaultInstance) return this;
                PrepareBuilder();
                ErrorCode = other.ErrorCode;
                return this;
            }

            /*
             * ErrorCode
             */
            public byte ErrorCode
            {
                get { return result.ErrorCode; }
                set { SetErrorCode(value); }
            }
            public Builder SetErrorCode(byte value)
            {
                PrepareBuilder();
                result.ErrorCode = value;
                return this;
            }
            public Builder ClearErrorCode()
            {
                PrepareBuilder();
                result.ErrorCode = Convert.ToByte(0);
                return this;
            }

            public Sc_Notify_Ban Build()
            {
                return result;
            }
        }

        public static Builder CreateBuilder() { return new Builder(); }
    }
}
