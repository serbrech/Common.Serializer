using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Serializer.Binary
{
    public static class Extensions
    {
        public static ISerialize Binary(this ISerializationContext context)
        {
            return new BinarySerializerAdapter();
        }
    }
}
