using Common.Serializer.NewtonsoftJson;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

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
        public void SerializeStreamTest()
        {
            using (var stream = new MemoryStream()) {
                Serialization.Serialize(stream, deserializedType);
                stream.Position = 0;
                var sr = new StreamReader(stream);
                var myStr = sr.ReadToEnd();
                myStr.Should().Be(serializedString);
            }
        }

        [Test]
        public void DeserializeTest()
        {
            var result = Serialization.Deserialize<SerializeMe>(serializedString);
            Assert.AreEqual(deserializedType.IntProp, result.IntProp);
        }

        [Test]
        public void DeserializeStreamTest()
        {
            using (var stream = new MemoryStream())
            {
                //Create stream
                var sw = new StreamWriter(stream);
                sw.Write(serializedString);
                sw.Flush();
                var adapter = new JsonSerializerAdapter();
                var theType = adapter.Deserialize<SerializeMe>(stream);
                theType.IntProp.Should().Be(1000);
                theType.SomeString.Should().Be(deserializedType.SomeString);
            }
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
