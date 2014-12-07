using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Common.Serializer.Xml
{
    public class DatacontractSerializerAdapter : ISerialize
    {
        private readonly Encoding _encoding;

        public DatacontractSerializerAdapter() : this(Encoding.UTF8)
        {
        }

        public DatacontractSerializerAdapter(Encoding encoding)
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

        public T Deserialize<T>(string serializedObj)
        {
            using (XmlReader reader = XmlReader.Create(new StringReader(serializedObj)))
            {
                var serializer = new DataContractSerializer(typeof(T));
                return (T) serializer.ReadObject(reader);
            }
        }

    }
}
