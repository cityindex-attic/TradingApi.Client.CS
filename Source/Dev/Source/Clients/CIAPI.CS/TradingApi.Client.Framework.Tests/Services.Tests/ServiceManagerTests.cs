using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class ServiceManagerTests
    {
        private IApiConnection _mockApiConnection;
        private MarketInfoServiceFactory _mockMarketInfoServiceFactory;
        private AccountInfoServiceFactory _mockAccountInfoServiceFactory;
        private CfdMarketServiceFactory _mockCfdMarketServiceFactory;
        private OrderServiceFactory _mockOrderServiceFactory;
        private ServiceManager _serviceManager;

        [SetUp]
        public void Setup()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
            _mockMarketInfoServiceFactory = MockRepository.GenerateMock<MarketInfoServiceFactory>();
            _mockAccountInfoServiceFactory = MockRepository.GenerateMock<AccountInfoServiceFactory>();
            _mockCfdMarketServiceFactory = MockRepository.GenerateMock<CfdMarketServiceFactory>();
            _mockOrderServiceFactory = MockRepository.GenerateMock<OrderServiceFactory>();

            _serviceManager = new ServiceManager();
            _serviceManager.SetUpServiceManagerForMocking(_mockApiConnection, _mockMarketInfoServiceFactory, _mockAccountInfoServiceFactory, _mockCfdMarketServiceFactory, _mockOrderServiceFactory);
        }

        [Test]
        public void MarketInformationServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var expectedMarketServiceReturned = new MarketInfoService(new MarketInformationQuery(_mockApiConnection.CoreConnection));

            _mockMarketInfoServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(expectedMarketServiceReturned)
                .Repeat.Once();

            // Act
            var marketService = _serviceManager.MarketInfoService;
            var marketServiceSecondCall = _serviceManager.MarketInfoService;

            // Assert
            Assert.AreEqual(expectedMarketServiceReturned, marketService);
            Assert.AreEqual(marketService, marketServiceSecondCall);
            _mockMarketInfoServiceFactory.VerifyAllExpectations();
        }

        [Test]
        public void AccountInfoServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var expectedAccountServiceReturned = new AccountInfoService(new AccountInformationQuery(_mockApiConnection.CoreConnection));

            _mockAccountInfoServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(expectedAccountServiceReturned)
                .Repeat.Once();

            // Act
            var accountInfoService = _serviceManager.AccountInfoService;
            var accountInfoServiceSecondCall = _serviceManager.AccountInfoService;

            // Assert
            Assert.AreEqual(expectedAccountServiceReturned, accountInfoService);
            Assert.AreEqual(accountInfoService, accountInfoServiceSecondCall);
            _mockAccountInfoServiceFactory.VerifyAllExpectations();
        }

        [Test]
        public void CfdMarketServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var expectedCfdMarketServiceReturned = new CfdMarketService(new CfdMarketQuery(_mockApiConnection.CoreConnection));

            _mockCfdMarketServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(expectedCfdMarketServiceReturned)
                .Repeat.Once();

            // Act
            var cfdMarketService = _serviceManager.CfdMarketService;
            var cfdMarketServiceSecondCall = _serviceManager.CfdMarketService;

            // Assert
            Assert.AreEqual(expectedCfdMarketServiceReturned, cfdMarketService);
            Assert.AreEqual(cfdMarketService, cfdMarketServiceSecondCall);
            _mockAccountInfoServiceFactory.VerifyAllExpectations();
        }

        [Test]
        public void OrderServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var expectedOrderServiceReturned = new OrderService(new OpenPositionsQuery(_mockApiConnection.CoreConnection), new OrderQuery(_mockApiConnection.CoreConnection), new StopLimitOrderHistoryQuery(_mockApiConnection.CoreConnection));

            _mockOrderServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(expectedOrderServiceReturned)
                .Repeat.Once();

            // Act
            var orderService = _serviceManager.OrderService;
            var orderServiceSecondCall = _serviceManager.OrderService;

            // Assert
            Assert.AreEqual(expectedOrderServiceReturned, orderService);
            Assert.AreEqual(orderService, orderServiceSecondCall);
            _mockOrderServiceFactory.VerifyAllExpectations();
        }
    }
}
