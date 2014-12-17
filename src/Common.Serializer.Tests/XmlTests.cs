using NUnit.Framework;
using Common.Serializer.Xml;
using FluentAssertions;
using System.IO;

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

        string xmlSerialized = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<SerializeMe xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <IntProp>1</IntProp>\r\n  <SomeString>Unicorns!</SomeString>\r\n</SerializeMe>";
        SerializeMe deserializedType = new SerializeMe { IntProp = 1, SomeString = "Unicorns!"};

        [Test]
        public void TestDefaultSerialize()
        {
            var result = Serialization.Serialize(deserializedType);
            result.Should().Be(xmlSerialized);
        }

        [Test]
        public void TestStreamSerialize()
        {
            using (var stream = new MemoryStream())
            {
                Serialization.Serialize(stream, deserializedType);
                stream.Position = 0;
                var sr = new StreamReader(stream);
                var myStr = sr.ReadToEnd();
                myStr.Should().Be(xmlSerialized);
            }
        }

        [Test]
        public void TestDefaultDeserialize()
        {
            var expected = new SerializeMe() { IntProp = 1 };
            var result = Serialization.Deserialize<SerializeMe>(xmlSerialized);
            Assert.AreEqual(expected.IntProp, result.IntProp);
        }

        [Test]
        public void TestDeserializeStream()
        {
            using (var stream = new MemoryStream())
            {
                //Create xmlMemoryStream stream
                var sw = new StreamWriter(stream);
                sw.Write(xmlSerialized);
                sw.Flush();
                //Deserialize
                var adapter = new XmlSerializerAdapter();
                var theType = adapter.Deserialize<SerializeMe>(stream);
                //Assert
                theType.IntProp.Should().Be(1);
                theType.SomeString.Should().Be(deserializedType.SomeString);
                theType.GetType().Should().Be(typeof(SerializeMe));
            }
        }

    }
}
