using System.Text;
using Common.Serializer.NewtonsoftJson;
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
                config.DefaultAdapter = new DatacontractSerializerAdapter(Encoding.UTF8);
            });

            Serialization.With.Default().Should().BeOfType<DatacontractSerializerAdapter>();
        }

        [Test]
        public void UseNonDefaultSerializer()
        {
            Serialization.Initialize(config =>
            {
                config.DefaultAdapter = new DatacontractSerializerAdapter(Encoding.UTF8);
            });

            Serialization.With.Json().Should().BeOfType<JsonSerializerAdapter>();
        }
    }
}
