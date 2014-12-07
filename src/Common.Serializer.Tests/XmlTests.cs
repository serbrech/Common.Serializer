using NUnit.Framework;
using Common.Serializer.Xml;
using FluentAssertions;

namespace Common.Serializer.Tests
{
    [TestFixture]
    public class XmlTests
    {
        [SetUp]
        public void Setup()
        {
            Serialization.Initialize(config =>
            {
                config.DefaultAdapter = new XmlSerializerAdapter();
            });
        }

        string xmlSerialized = @"<?xml version=""1.0"" encoding=""utf-16""?>
<SerializeMe xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <IntProp>1</IntProp>
  <SomeString />
</SerializeMe>";


        [Test]
        public void TestDefaultSerialize()
        {
            var result = Serialization.Serialize(new SerializeMe { IntProp = 1, SomeString = ""});
            result.Should().Be(xmlSerialized);
        }

        [Test]
        public void TestDefaultDeserialize()
        {
            var expected = new SerializeMe() { IntProp = 1 };
            var result = Serialization.Deserialize<SerializeMe>(xmlSerialized);
            Assert.AreEqual(expected.IntProp, result.IntProp);
        }

    }
}
