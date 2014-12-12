using YamlDotNet.Serialization;

namespace Common.Serializer.YamlDotNet
{
    public static class Extensions
    {
        public static ISerialize Yaml(this ISerializationContext context, SerializationOptions options = SerializationOptions.None, INamingConvention namingConvention = null)
        {
            return new YamlSerializerAdapter(options, namingConvention);
        }
    }
}