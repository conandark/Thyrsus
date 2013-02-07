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
    [Method((ushort)HEADER.HEADER_HC_SECOND_PASSWD_LOGIN, "HC_SECOND_PASSWD_LOGIN", MethodAttribute.Packetdirection.PdOut, 0)]
    public class Hc_Second_Password_Login : IPacketOut
    {
        private static readonly Hc_Second_Password_Login defaultInstance = new Hc_Second_Password_Login().MakeReadOnly();

        private Hc_Second_Password_Login MakeReadOnly()
        {
            return this;
        }

        public static Hc_Second_Password_Login DefaultInstance
        {
            get { return defaultInstance; }
        }

        public int Seed { get; private set; }
        public int Aid { get; private set; }
        public short Result { get; private set; }

        public void WriteTo(BinaryWriter output)
        {
            output.Write((ushort)HEADER.HEADER_HC_SECOND_PASSWD_LOGIN);
            output.Write(Seed);
            output.Write(Aid);
            output.Write(Result);
        }

        public sealed partial class Builder
        {
            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private Hc_Second_Password_Login result;

            private Hc_Second_Password_Login PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    Hc_Second_Password_Login original = result;
                    result = new Hc_Second_Password_Login();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public Builder MergeFrom(Hc_Second_Password_Login other)
            {
                if (other == DefaultInstance) return this;
                PrepareBuilder();
                return this;
            }

            /*
             * Seed
             */
            public int Seed
            {
                get { return result.Seed; }
                set { SetSeed(value); }
            }
            public Builder SetSeed(int value)
            {
                PrepareBuilder();
                result.Seed = value;
                return this;
            }
            public Builder ClearSeed()
            {
                PrepareBuilder();
                result.Seed = 0;
                return this;
            }

            /*
             * Aid
             */
            public int Aid
            {
                get { return result.Aid; }
                set { SetAid(value); }
            }
            public Builder SetAid(int value)
            {
                PrepareBuilder();
                result.Aid = value;
                return this;
            }
            public Builder ClearAid()
            {
                PrepareBuilder();
                result.Aid = 0;
                return this;
            }

            /*
             * Result
             */
            public short Result
            {
                get { return result.Result; }
                set { SetResult(value); }
            }
            public Builder SetResult(short value)
            {
                PrepareBuilder();
                result.Result = value;
                return this;
            }
            public Builder ClearResult()
            {
                PrepareBuilder();
                result.Result = 0;
                return this;
            }

            public Hc_Second_Password_Login Build()
            {
                return result;
            }
        }

        public static Builder CreateBuilder() { return new Builder(); }
    }
}