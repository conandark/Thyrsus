using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Account.Classes.Network
{
    public class Buffer
    {
        public int Position { get; private set; }

        public int Length
        {
            get { return _length - Position; }
        }

        private byte[] _data = new byte[0];
        private int _length;

        public Buffer()
        {
            Position = 0;
        }

        public bool PacketAvaliable()
        {
            if (Length < 2)
                return false;

            var header = Header.ParseFrom(_data);
            if (Length < header.HeaderSize + header.Size)
                return false;

            return true;
        }

        public Packet GetPacket()
        {
            if ((Length < 2))
            {
                throw new Exception("GetPacket when insuficient header data avaliable");
            }
            var ret = new Packet();
            ret.Header = Header.ParseFrom(_data);

            if ((Length < ret.Header.Size))
            {
                throw new Exception("GetPacket when insuficient data avaliable");
            }
            Position += ret.Header.HeaderSize;
            ret.Data = new byte[ret.Header.Size];

            Array.Copy(_data, Position, ret.Data, 0, ret.Header.Size);
            Position = (Position + ret.Header.Size);

            return ret;
        }

        public void Consume()
        {
            var nb = new byte[Length];
            Array.Copy(_data, Position, nb, 0, Length);
            _data = nb;
            _length = _length - Position;
            Position = 0;
        }

        public void Clear()
        {
            Position = _length;
            Consume();
        }

        public void Append(byte[] newdata)
        {
            if (_data.Length < _length + newdata.Length)
                Array.Resize(ref _data, _length + newdata.Length);

            Array.Copy(newdata, 0, _data, _length, newdata.Length);
            _length = _length + newdata.Length;
        }

        public void Append(byte[] newdata, int length)
        {
            if (_data.Length < _length + length)
                Array.Resize(ref _data, _length + length);

            Array.Copy(newdata, 0, _data, _length, length);
            _length = _length + length;
        }
    }
}
