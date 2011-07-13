using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class NewsServiceFactoryTests
    {
        private IApiConnection _mockApiConnection;

        [SetUp]
        public void Setup()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
        }

        [Test]
        public void NewsServiceFactoryCreatesNewsServiceWithAValidApiConnection()
        {
            var service = new NewsServiceFactory().Create(_mockApiConnection);
            Assert.IsInstanceOfType(typeof(NewsService), service);
        }
    }
}
