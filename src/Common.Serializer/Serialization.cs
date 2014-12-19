using System;
using Common.Serializer.Xml;
using System.IO;

namespace Common.Serializer
{
    public class Serialization
    {
        private static readonly SerializationConfiguration Configuration;

        private static readonly Lazy<ISerializationContext> SerializationContext =
            new Lazy<ISerializationContext>(() => new SerializationContext(Configuration));
        
        public static ISerializationContext With { get { return SerializationContext.Value; } }

        static Serialization()
        {
            Configuration = new SerializationConfiguration
            {
                DefaultAdapter = new XmlSerializerAdapter()
            };
        }

        public static string Serialize<T>(T obj)
        {
            return With.Default().Serialize(obj);
        }

        public static void Serialize<T>(Stream stream, T obj)
        {
            if (!stream.CanWrite)
            {
                throw new IOException("The input stream is not writeable");
            }
            With.Default().Serialize(stream, obj);
        }

        public static T Deserialize<T>(string serializedObj) where T : new()
        {
            return With.Default().Deserialize<T>(serializedObj);
        }

        public static T Deserialize<T>(Stream serializedStream) where T : new()
        {
            if (!serializedStream.CanRead) {
                throw new IOException("The serialized stream is not readable");
            }
            return With.Default().Deserialize<T>(serializedStream);
        }

        public static void Initialize(Action<SerializationConfiguration> configure)
        {
            configure(Configuration);
        }
    }
}
