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
    [Method((ushort)HEADER.HEADER_AC_ACCEPT_LOGIN, "AC_ACCEPT_LOGIN", MethodAttribute.Packetdirection.PdOut, 0)]
    public class Ac_Accept_Login : IPacketOut
    {
        private static readonly Ac_Accept_Login defaultInstance = new Ac_Accept_Login().MakeReadOnly();

        private Ac_Accept_Login MakeReadOnly()
        {
            return this;
        }

        public static Ac_Accept_Login DefaultInstance
        {
            get { return defaultInstance; }
        }

        public int AuthCode { get; private set; }
        public int AID { get; private set; }
        public int UserLevel { get; private set; }
        public int LastLoginIP { get; private set; }
        public string LastLoginTime { get; private set; }
        public byte Gender { get; private set; }

        public void WriteTo(BinaryWriter output)
        {
            var characterServers = Worker.Singleton.Serverlist.Where(s => s.type == ServerTypes.Character).ToArray();

            output.Write((ushort)HEADER.HEADER_AC_ACCEPT_LOGIN);
            output.Write(Convert.ToInt16(47 + (characterServers.Count() * 32)));
            output.Write(AuthCode);
            output.Write(AID);
            output.Write(UserLevel);
            output.Write(LastLoginIP);
            output.WriteCString(LastLoginTime, 26);
            output.Write(Gender);
            foreach (var srv in characterServers)
            {
                Logging.Debug(string.Format("{0}, {1}, {2}", srv.name, srv.ip, srv.port));
                output.Write((int)srv.ip);
                output.Write((short)srv.port);
                output.WriteCString(srv.name, 20);
                output.Write(srv.count);
                output.WriteCString(string.Empty, 2);
            }
        }

        public sealed partial class Builder
        {
            public Builder()
            {
                result = DefaultInstance;
                resultIsReadOnly = true;
            }

            private bool resultIsReadOnly;
            private Ac_Accept_Login result;

            private Ac_Accept_Login PrepareBuilder()
            {
                if (resultIsReadOnly)
                {
                    Ac_Accept_Login original = result;
                    result = new Ac_Accept_Login();
                    resultIsReadOnly = false;
                    MergeFrom(original);
                }
                return result;
            }

            public Builder MergeFrom(Ac_Accept_Login other)
            {
                if (other == DefaultInstance) return this;
                PrepareBuilder();
                AuthCode = other.AuthCode;
                return this;
            }

            /*
             * AuthCode
             */
            public int AuthCode
            {
                get { return result.AuthCode; }
                set { SetAuthCode(value); }
            }
            public Builder SetAuthCode(int value)
            {
                PrepareBuilder();
                result.AuthCode = value;
                return this;
            }
            public Builder ClearAuthCode()
            {
                PrepareBuilder();
                result.AuthCode = 0;
                return this;
            }

            /*
             * AID
             */
            public int AID
            {
                get { return result.AID; }
                set { SetAID(value); }
            }
            public Builder SetAID(int value)
            {
                PrepareBuilder();
                result.AID = value;
                return this;
            }
            public Builder ClearAID()
            {
                PrepareBuilder();
                result.AID = 0;
                return this;
            }

            /*
             * UserLevel
             */
            public int UserLevel
            {
                get { return result.UserLevel; }
                set { SetUserLevel(value); }
            }
            public Builder SetUserLevel(int value)
            {
                PrepareBuilder();
                result.UserLevel = value;
                return this;
            }
            public Builder ClearUserLevel()
            {
                PrepareBuilder();
                result.UserLevel = 0;
                return this;
            }

            /*
             * LastLoginIP
             */
            public int LastLoginIP
            {
                get { return result.LastLoginIP; }
                set { SetLastLoginIP(value); }
            }
            public Builder SetLastLoginIP(int value)
            {
                PrepareBuilder();
                result.LastLoginIP = value;
                return this;
            }
            public Builder ClearLastLoginIP()
            {
                PrepareBuilder();
                result.LastLoginIP = 0;
                return this;
            }

            /*
             * LastLoginTime
             */
            public string LastLoginTime
            {
                get { return result.LastLoginTime; }
                set { SetLastLoginTime(value); }
            }
            public Builder SetLastLoginTime(string value)
            {
                PrepareBuilder();
                result.LastLoginTime = value;
                return this;
            }
            public Builder ClearLastLoginTime()
            {
                PrepareBuilder();
                result.LastLoginTime = String.Empty;
                return this;
            }

            /*
             * Gender
             */
            public byte Gender
            {
                get { return result.Gender; }
                set { SetGender(value); }
            }
            public Builder SetGender(byte value)
            {
                PrepareBuilder();
                result.Gender = value;
                return this;
            }
            public Builder ClearGender()
            {
                PrepareBuilder();
                result.Gender = 0;
                return this;
            }

            public Ac_Accept_Login Build()
            {
                return result;
            }
        }

        public static Builder CreateBuilder() { return new Builder(); }
    }
}
