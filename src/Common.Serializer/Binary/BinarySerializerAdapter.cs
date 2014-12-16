using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Serializer.Binary
{
    public class BinarySerializerAdapter : ISerialize
    {
        public string Serialize<T>(T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, obj);
                memoryStream.Flush();
                memoryStream.Position = 0;
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
        public void Serialize<T>(Stream stream, T obj)
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, obj);
        }

        public T Deserialize<T>(string serializedObj)
        {
            var base64String = Convert.FromBase64String(serializedObj);
            using (var memoryStream = new MemoryStream(base64String))
            {
                var binaryFormatter = new BinaryFormatter();
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (T)binaryFormatter.Deserialize(memoryStream);
            }
        }

        
    }
}
