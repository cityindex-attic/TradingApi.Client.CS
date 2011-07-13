using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class MessageServiceFactoryTests
    {
        private IApiConnection _mockApiConnection;

        [SetUp]
        public void Setup()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
        }

        [Test]
        public void FutureOptionServiceFactoryCreatesFutureOptionServiceWithAValidApiConnection()
        {
            var service = new MessageServiceFactory().Create(_mockApiConnection);
            Assert.IsInstanceOfType(typeof(MessageService), service);
        }
    }
}
