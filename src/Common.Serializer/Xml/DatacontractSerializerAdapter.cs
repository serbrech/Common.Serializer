using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Common.Serializer.Xml
{
    public class DataContractSerializerAdapter : ISerialize
    {
        private readonly Encoding _encoding;

        public DataContractSerializerAdapter() : this(Encoding.UTF8)
        {
        }

        public DataContractSerializerAdapter(Encoding encoding)
        {
            _encoding = encoding;
        }

        public string Serialize<T>(T obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(memoryStream, obj);
                return _encoding.GetString(memoryStream.ToArray());
            }
        }
        public void Serialize<T>(Stream stream, T obj)
        {
            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(stream, obj);
        }
        public T Deserialize<T>(string serializedObj)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(serializedObj)))
            {
                var serializer = new DataContractSerializer(typeof(T));
                return (T) serializer.ReadObject(reader);
            }
        }

        public T Deserialize<T>(Stream xmlStream)
        {
            xmlStream.Position = 0;
            var sr = new StreamReader(xmlStream);
            using (var str = new StringReader(sr.ReadToEnd()))
            {
                return this.Deserialize<T>(str.ToString());
            }
        }
    }
}
