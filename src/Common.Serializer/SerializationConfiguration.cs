using System.Text;

namespace Common.Serializer
{
    public class SerializationConfiguration
    {
        public ISerialize DefaultAdapter { get; set; }

        public SerializationConfiguration WithDefaultSerializer(ISerialize serializer)
        {
            DefaultAdapter = serializer;
            return this;
        }
    }
}