using System.Text;
using Common.Serializer.Xml;
using FluentAssertions;
using NUnit.Framework;

namespace Common.Serializer.Tests
{
    [TestFixture]
    public class ConfigTest
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
        public void DefaultConfig()
        {
            Serialization.With.Default().Should().BeOfType<XmlSerializerAdapter>();
        }

        [Test]
        public void DatacontractSerializerConfig()
        {
            Serialization.Initialize(config =>
            {
                config.DefaultAdapter = new DataContractSerializerAdapter(Encoding.UTF8);
            });

            Serialization.With.Default().Should().BeOfType<DataContractSerializerAdapter>();
        }

        [Test]
        public void UseNonDefaultSerializer()
        {
            Serialization.Initialize(config =>
            {
                config.DefaultAdapter = new DataContractSerializerAdapter(Encoding.UTF8);
            });

            Serialization.With.Xml().Should().BeOfType<XmlSerializerAdapter>();
        }
    }
}
