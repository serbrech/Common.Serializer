namespace Common.Serializer
{
    internal class SerializationContext : ISerializationContext
    {
        private readonly SerializationConfiguration _configuration;

        public ISerialize Default()
        {
            return _configuration.DefaultAdapter;
        }

        public SerializationContext(SerializationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Serialize<T>(T obj)
        {
            return Default().Serialize(obj);
        }

        public T Deserialize<T>(string serializedObj) where T : new()
        {
            return Default().Deserialize<T>(serializedObj);
        }
    }

    
}