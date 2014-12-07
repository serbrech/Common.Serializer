using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serializer.NewtonsoftJson
{
    public static class Extensions
    {
        public static ISerialize Json(this ISerializationContext context)
        {
            return new JsonSerializerAdapter();
        }
    }
}
