using Common.Serializer.NewtonsoftJson;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Common.Serializer.Tests
{
    [TestFixture]
    public class JsonTest
    {
        string serializedString = "{\"IntProp\":1000,\"SomeString\":\"This is some nasty string... not really\"}";
        SerializeMe deserializedType = new SerializeMe
        {
            IntProp = 1000,
            SomeString = "This is some nasty string... not really"
        };

        [SetUp]
        public void Setup()
        {
            Serialization.Initialize(config =>
            {
                config.DefaultAdapter = new JsonSerializerAdapter();
            });
        }

        [Test]
        public void SerializeTest()
        {
            Serialization.Serialize(deserializedType)
            .Should().Be(serializedString);
        }

        [Test]
        public void DeserializeTest()
        {
            var result = Serialization.Deserialize<SerializeMe>(serializedString);
            Assert.AreEqual(deserializedType.IntProp, result.IntProp);
        }

        [Test]
        public void SerializeTListTest()
        {
            IEnumerable<SerializeMe> list = new List<SerializeMe>{ deserializedType, deserializedType};
            Serialization.Serialize(list)
            .Should().Be(string.Format("[{0},{1}]", serializedString, serializedString));
        }
    }
}
