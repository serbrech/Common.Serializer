using System;
using System.IO;
using System.Xml.Serialization;

namespace Common.Serializer.Xml
{
    public class XmlSerializerAdapter : ISerialize
    {
        public string Serialize<T>(T obj)
        {
            using (var writer = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }
        public void Serialize<T>(Stream stream, T obj)
        {
            var sw = new StreamWriter(stream, System.Text.Encoding.GetEncoding("UTF-16"));
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(sw, obj);
        }

        public T Deserialize<T>(string serializedObj)
        {
            using (var reader = new StringReader(serializedObj))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T) serializer.Deserialize(reader);
            }
        }

        
    }
}