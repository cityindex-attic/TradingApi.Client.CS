using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamFactory;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Tests.StreamingTests.LightStreamerTests.StreamFactoryTests
{
    [TestFixture]
    public class OrderStreamFactoryTests
    {
        private ILsStreamingClientAccountConnection _mockLsStreamingClientAccountConnection;

        [SetUp]
        public void Setup()
        {
            _mockLsStreamingClientAccountConnection = MockRepository.GenerateMock<ILsStreamingClientAccountConnection>();
        }
        
        [Test]
        public void OrderStreamFactoryCreatesOrderStreamListener()
        {
            var orderStream = new OrderStreamFactory().Create(_mockLsStreamingClientAccountConnection);
            Assert.IsInstanceOfType(typeof(OrderStream), orderStream);
        }
    }
}
