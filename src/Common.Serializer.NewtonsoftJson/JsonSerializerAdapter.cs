using System;
using System.IO;
using Newtonsoft.Json;

namespace Common.Serializer.NewtonsoftJson
{
    public class JsonSerializerAdapter : ISerialize
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public void Serialize<T>(Stream stream, T obj)
        {
            StreamWriter writer = new StreamWriter(stream);
            JsonTextWriter jsonWriter = new JsonTextWriter(writer);
            JsonSerializer ser = new JsonSerializer();
            ser.Serialize(jsonWriter, obj);
            jsonWriter.Flush();
        }
        public T Deserialize<T>(string serializedObj)
        {
            return JsonConvert.DeserializeObject<T>(serializedObj);
        }

        
    }
}
