using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class CfdMarketServiceFactoryTests
    {
        private IApiConnection _mockApiConnection;

        [SetUp]
        public void Setup()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
        }

        [Test]
        public void CfdMarketServiceFactoryCreatesCfdMarketServiceWithAValidApiConnection()
        {
            var service = new CfdMarketServiceFactory().Create(_mockApiConnection);
            Assert.IsInstanceOfType(typeof(CfdMarketService), service);
        }
    }
}
