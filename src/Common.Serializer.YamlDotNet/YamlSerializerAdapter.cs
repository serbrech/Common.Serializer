using System.IO;
using YamlDotNet.Serialization;
using YamlDotNetSerializer = YamlDotNet.Serialization.Serializer;

namespace Common.Serializer.YamlDotNet
{
    public class YamlSerializerAdapter : ISerialize
    {
        private readonly SerializationOptions _options;
        private readonly INamingConvention _namingConvention;

        public YamlSerializerAdapter(SerializationOptions options = SerializationOptions.None, INamingConvention namingConvention = null)
        {
            _options = options;
            _namingConvention = namingConvention;
        }

        public string Serialize<T>(T obj)
        {
            var sw = new StringWriter();
            var serializer = new YamlDotNetSerializer(_options, _namingConvention);
            serializer.Serialize(sw, obj);
            return sw.ToString();
        }

        public T Deserialize<T>(string serializedObj)
        {
            return new Deserializer(namingConvention:_namingConvention).Deserialize<T>(new StringReader(serializedObj));
        }
    }
}
