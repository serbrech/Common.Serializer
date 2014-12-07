using Common.Serializer.NewtonsoftJson;
using FluentAssertions;
using NUnit.Framework;

namespace Common.Serializer.Tests
{
    [TestFixture]
    public class JsonTest
    {
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
            Serialization.Serialize(new SerializeMe
            {
                IntProp = 1000,
                SomeString = "This is some nasty string... not really"
            })
            .Should().Be("{\"IntProp\":1000,\"SomeString\":\"This is some nasty string... not really\"}");
        }
    }
}
