using System;
using NUnit.Framework;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory;

namespace TradingApi.Client.Framework.Tests.StreamingTests.LightStreamerTests.ConnectionTests.FactoryTests
{
    [TestFixture]
    public class DefaultCityindexStreamingConnectionFactoryTests
    {
        [Test]
        public void StreamingClientFactoryCreatesALightstreamerClient()
        {
            var lsCityindexStreamingClientConnection = new DefaultStreamingClientAccountConnectionFactory().Create(new Uri("http://couldBeAnyUrl/TradingApi"), "username", "session");
            Assert.IsInstanceOfType(typeof(LsGenericStreamingClientAccountConnection), lsCityindexStreamingClientConnection);
        }
    }
}
