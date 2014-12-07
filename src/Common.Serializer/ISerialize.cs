namespace Common.Serializer
{
    public interface ISerialize
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string serializedObj);
    }
}