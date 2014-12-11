using System.Text;

namespace Common.Serializer.Xml
{
    public static class Extensions
    {
        public static ISerialize Xml(this ISerializationContext context)
        {
            return new XmlSerializerAdapter();
        }

        public static ISerialize DataContract(this ISerializationContext context, Encoding encoding)
        {
            return new DataContractSerializerAdapter();
        }

        public static ISerialize DataContract(this ISerializationContext context)
        {
            return new DataContractSerializerAdapter(Encoding.UTF8);
        }
    }
}
