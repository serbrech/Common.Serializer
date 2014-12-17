using Common.Serializer.Xml;
using NUnit.Framework;
using FluentAssertions;
using System.IO;

namespace Common.Serializer.Tests
{
    [TestFixture]
    class SerializationTests
    {
        [SetUp]
        public void Setup()
        {
            Serialization.Initialize(config =>
            {
                config.DefaultAdapter = new XmlSerializerAdapter();
            });
        }

        [Test]
        [ExpectedException("System.IO.IOException")]
        public void SerializingStreamsMustBeWriteable()
        {
            var aObject = new {myProp = "Hello"};
            using (MemoryStream memStream = new MemoryStream(new byte[0], false)){
                Serialization.Serialize<object>(memStream, aObject);
            }
        }

        [Test]
        [ExpectedException("System.IO.IOException")]
        public void DeserializingStreamsMustBeReadable()
        {
            var aObject = new { myProp = "Hello" };
            using (MemoryStream memStream = new MemoryStream(new byte[0], false))
            {
                memStream.Close();
                Serialization.Deserialize<object>(memStream);
            }
        }
    }
}
