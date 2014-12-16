using System.Collections.Generic;
using Common.Serializer.YamlDotNet;
using FluentAssertions;
using NUnit.Framework;
using System.IO;

namespace Common.Serializer.Tests
{
    [TestFixture]
    public class YamlTest
    {
        string serializedYamlString = "IntProp: 1000\r\nSomeString: This is some nasty string... not really\r\n";
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
                config.DefaultAdapter = new YamlSerializerAdapter();
            });
        }

        [Test]
        public void SerializeTest()
        {
            Serialization.Serialize(deserializedType)
                .Should().Be(serializedYamlString);
        }

        [Test]
        public void SerializeStreamTest()
        {
            using (var stream = new MemoryStream())
            {
                Serialization.Serialize(stream, deserializedType);
                stream.Position = 0;
                var sr = new StreamReader(stream);
                var myStr = sr.ReadToEnd();
                myStr.Should().Be(serializedYamlString);
            }
        }

        [Test]
        public void DeSerializeTest()
        {
            var serializedObj = serializedYamlString;
            var result = Serialization.Deserialize<SerializeMe>(serializedObj);
            result.IntProp.Should().Be(deserializedType.IntProp);
            result.SomeString.Should().Be(deserializedType.SomeString);
        }

        [Test]
        public void SerializeDictionary()
        {
            var objectWithDictionary = new
            {
                dico = new Dictionary<string, string>()
                {
                    {"first key", "first value"},
                    {"second key", "second value"}
                }
            };
            var result = Serialization.Serialize(objectWithDictionary);
            result.Should().Be("dico:\r\n  first key: first value\r\n  second key: second value\r\n");

        }
    }
}