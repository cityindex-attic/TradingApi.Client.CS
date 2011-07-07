using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamFactory;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Tests.StreamingTests.LightStreamerTests.StreamFactoryTests
{
    [TestFixture]
    public class PriceStreamFactoryTests
    {
        private ILsCityindexStreamingConnection _mockLsCityindexStreamingConnection;

        [SetUp]
        public void Setup()
        {
            _mockLsCityindexStreamingConnection = MockRepository.GenerateMock<ILsCityindexStreamingConnection>();
        }
        
        [Test]
        public void PriceStreamFactoryCreatesPriceStreamListener()
        {
            var priceStream = new PriceStreamFactory().Create(_mockLsCityindexStreamingConnection);
            Assert.IsInstanceOfType(typeof(PriceStream), priceStream);
        }
    }
}
