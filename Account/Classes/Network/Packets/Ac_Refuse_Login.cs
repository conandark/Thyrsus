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
    [Method((ushort)HEADER.HEADER_AC_REFUSE_LOGIN, "AC_REFUSE_LOGIN", MethodAttribute.Packetdirection.PdOut, 0)]
    public class Ac_Refuse_Login : IPacketOut
    {
        private static readonly Ac_Refuse_Login defaultInstance = new Ac_Refuse_Login().MakeReadOnly();

        private Ac_Refuse_Login MakeReadOnly()
        {
            return this;
        }

        public static Ac_Refuse_Login DefaultInstance
        {
            get { return defaultInstance; }
        }

        public byte ErrorCode { get; private set; }
        public string BlockDate { get; private set; }

        public void WriteTo(BinaryWriter output)
        {
            output.Write((ushort)HEADER.HEADER_AC_REFUSE_LOGIN);
            output.Write(ErrorCode);
            output.WriteCString(BlockDate, 20);
        }

        public sealed partial class Builder
        {
            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private Ac_Refuse_Login result;

            private Ac_Refuse_Login PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    Ac_Refuse_Login original = result;
                    result = new Ac_Refuse_Login();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public Builder MergeFrom(Ac_Refuse_Login other)
            {
                if (other == DefaultInstance) return this;
                PrepareBuilder();
                ErrorCode = other.ErrorCode;
                BlockDate = other.BlockDate;
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

            /*
             * BlockDate
             */
            public string BlockDate
            {
                get { return result.BlockDate; }
                set { SetBlockDate(value); }
            }
            public Builder SetBlockDate(string value)
            {
                PrepareBuilder();
                result.BlockDate = value;
                return this;
            }
            public Builder ClearBlockDate()
            {
                PrepareBuilder();
                result.BlockDate = string.Empty;
                return this;
            }

            public Ac_Refuse_Login Build()
            {
                return result;
            }
        }

        public static Builder CreateBuilder() { return new Builder(); }
    }
}
