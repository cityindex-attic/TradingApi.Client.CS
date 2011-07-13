using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class MarketInformationServiceFactoryTests
    {
        private IApiConnection _mockApiConnection;
        
        [SetUp]
        public void Setup()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
        }
        
        [Test]
        public void MarketServiceFactoryCreatesMarketInfoServiceWithAValidApiConnection()
        {
            var service = new MarketInformationServiceFactory().Create(_mockApiConnection);
            Assert.IsInstanceOfType(typeof(MarketInformationService), service);
        }
    }
}
