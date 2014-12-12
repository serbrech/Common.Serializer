using System.Collections.Generic;
using Common.Serializer.YamlDotNet;
using FluentAssertions;
using NUnit.Framework;

namespace Common.Serializer.Tests
{
    [TestFixture]
    public class YamlTest
    {
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
            var serializeMe = new SerializeMe
            {
                IntProp = 1000,
                SomeString = "This is some nasty string... not really"
            };

            Serialization.Serialize(serializeMe)
                .Should().Be("IntProp: 1000\r\nSomeString: This is some nasty string... not really\r\n");
        }


        [Test]
        public void DeSerializeTest()
        {
            var serializedObj = "IntProp: 1000\r\nSomeString: This is some nasty string... not really\r\n";
            var result = Serialization.Deserialize<SerializeMe>(serializedObj);
            result.IntProp.Should().Be(1000);
            result.SomeString.Should().Be("This is some nasty string... not really");

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