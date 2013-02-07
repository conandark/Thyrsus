using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.Shared.Network
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MethodAttribute : Attribute
    {
        public const int PacketLengthDynamic = -1;
        public enum Packetdirection
        {
            PdNone,
            PdIn,
            PdOut
        }

        public ushort MethodId { get; private set; }
        public string Name { get; private set; }
        public int Size { get; private set; }
        public Packetdirection Direction { get; private set; }

        public MethodAttribute(ushort methodId, string name, Packetdirection direction, int size)
        {
            MethodId = methodId;
            Name = name;
            Size = size;
            Direction = direction;
        }
    }

    public static class Method
    {
        public readonly static Dictionary<Type, MethodAttribute> ProvidedMethods = new Dictionary<Type, MethodAttribute>();
        public readonly static Dictionary<Type, IPacketIn> Methods = new Dictionary<Type, IPacketIn>();

        static Method()
        {
            foreach (var type in Assembly.GetEntryAssembly().GetTypes().Where(type => type.GetInterface(typeof(IPacketIn).Name) != null))
            {
                object[] attributes = type.GetCustomAttributes(typeof(MethodAttribute), true);
                if (attributes.Length == 0) return;

                ProvidedMethods.Add(type, (MethodAttribute)attributes[0]);
                Methods.Add(type, (IPacketIn)Activator.CreateInstance(type));
            }
        }

        public static int Count()
        {
            return ProvidedMethods.Count();
        }

        public static IPacketIn GetById(ushort methodId)
        {
            return (from pair in ProvidedMethods let methodInfo = pair.Value where methodInfo.MethodId == methodId select Methods[pair.Key]).FirstOrDefault();
        }

        public static int GetSize(ushort methodId)
        {
            return (from pair in ProvidedMethods let methodInfo = pair.Value where methodInfo.MethodId == methodId select pair.Value.Size).FirstOrDefault();
        }
    }
}
