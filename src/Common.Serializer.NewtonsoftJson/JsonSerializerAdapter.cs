using Newtonsoft.Json;

namespace Common.Serializer.NewtonsoftJson
{
    public class JsonSerializerAdapter : ISerialize
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Deserialize<T>(string serializedObj)
        {
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }
    }
}
