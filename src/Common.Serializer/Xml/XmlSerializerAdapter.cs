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