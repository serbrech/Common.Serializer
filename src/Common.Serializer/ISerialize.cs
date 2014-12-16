using System.IO;

namespace Common.Serializer
{
    public interface ISerialize
    {
        string Serialize<T>(T obj);
        void Serialize<T>(Stream stream, T obj);

        T Deserialize<T>(string serializedObj);

    }
}