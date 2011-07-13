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
        private MarketInformationServiceFactory _mockMarketInformationServiceFactory;
        private AccountInformationServiceFactory _mockAccountInformationServiceFactory;
        private CfdMarketServiceFactory _mockCfdMarketServiceFactory;
        private OrderServiceFactory _mockOrderServiceFactory;
        private FutureOptionServiceFactory _mockFutureOptionServiceFactory;
        private MessageServiceFactory _mockMessageServiceFactory;
        private NewsServiceFactory _mockNewsServiceFactory;
        private SpreadMarketServiceFactory _spreadMarketServiceFactory;
        private ServiceManager _serviceManager;

        [SetUp]
        public void Setup()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
            _mockMarketInformationServiceFactory = MockRepository.GenerateMock<MarketInformationServiceFactory>();
            _mockAccountInformationServiceFactory = MockRepository.GenerateMock<AccountInformationServiceFactory>();
            _mockCfdMarketServiceFactory = MockRepository.GenerateMock<CfdMarketServiceFactory>();
            _mockOrderServiceFactory = MockRepository.GenerateMock<OrderServiceFactory>();
            _mockFutureOptionServiceFactory = MockRepository.GenerateMock<FutureOptionServiceFactory>();
            _mockMessageServiceFactory = MockRepository.GenerateMock<MessageServiceFactory>();
            _mockNewsServiceFactory = MockRepository.GenerateMock<NewsServiceFactory>();
            _spreadMarketServiceFactory = MockRepository.GenerateMock<SpreadMarketServiceFactory>();

            _serviceManager = new ServiceManager();
            _serviceManager.SetUpServiceManagerForMocking(
                _mockApiConnection, 
                _mockMarketInformationServiceFactory, 
                _mockAccountInformationServiceFactory, 
                _mockCfdMarketServiceFactory, 
                _mockOrderServiceFactory, 
                _mockFutureOptionServiceFactory,
                _mockMessageServiceFactory,
                _mockNewsServiceFactory,
                _spreadMarketServiceFactory);
        }

        [Test]
        public void MarketInformationServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var expectedMarketServiceReturned = new MarketInformationService(new MarketInformationQuery(_mockApiConnection.CoreConnection));

            _mockMarketInformationServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(expectedMarketServiceReturned)
                .Repeat.Once();

            // Act
            var marketService = _serviceManager.MarketInformationService;
            var marketServiceSecondCall = _serviceManager.MarketInformationService;

            // Assert
            Assert.AreEqual(expectedMarketServiceReturned, marketService);
            Assert.AreEqual(marketService, marketServiceSecondCall);
            _mockMarketInformationServiceFactory.VerifyAllExpectations();
        }

        [Test]
        public void AccountInformationServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var expectedAccountServiceReturned = new AccountInformationService(new AccountInformationQuery(_mockApiConnection.CoreConnection));

            _mockAccountInformationServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(expectedAccountServiceReturned)
                .Repeat.Once();

            // Act
            var accountInfoService = _serviceManager.AccountInformationService;
            var accountInfoServiceSecondCall = _serviceManager.AccountInformationService;

            // Assert
            Assert.AreEqual(expectedAccountServiceReturned, accountInfoService);
            Assert.AreEqual(accountInfoService, accountInfoServiceSecondCall);
            _mockAccountInformationServiceFactory.VerifyAllExpectations();
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
            _mockAccountInformationServiceFactory.VerifyAllExpectations();
        }

        [Test]
        public void OrderServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var expectedOrderServiceReturned = new OrderService(
                new OpenPositionsQuery(_mockApiConnection.CoreConnection), 
                new OrderQuery(_mockApiConnection.CoreConnection), 
                new StopLimitOrderHistoryQuery(_mockApiConnection.CoreConnection), 
                new NewStopLimitOrderPlacer(_mockApiConnection.CoreConnection), 
                new NewTradeOrderPlacer(_mockApiConnection.CoreConnection),
                new CancelOrderPlacer(_mockApiConnection.CoreConnection),
                new ActiveStopLimitOrderQuery(_mockApiConnection.CoreConnection),
                new TradeHistoryQuery(_mockApiConnection.CoreConnection));

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

        [Test]
        public void FutureOptionServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var futureOptionServiceReturned = new FutureOptionService(new FutureOptionPlacer(_mockApiConnection.CoreConnection));

            _mockFutureOptionServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(futureOptionServiceReturned)
                .Repeat.Once();

            // Act
            var futureOptionService = _serviceManager.FutureOptionService;
            var serviceSecondCall = _serviceManager.FutureOptionService;

            // Assert
            Assert.AreEqual(futureOptionServiceReturned, futureOptionService);
            Assert.AreEqual(futureOptionService, serviceSecondCall);
            _mockFutureOptionServiceFactory.VerifyAllExpectations();
        }

        [Test]
        public void MessageServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var serviceReturned = new MessageService(new MessageLookupQuery(_mockApiConnection.CoreConnection));

            _mockMessageServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(serviceReturned)
                .Repeat.Once();

            // Act
            var messageService = _serviceManager.MessageService;
            var serviceSecondCall = _serviceManager.MessageService;

            // Assert
            Assert.AreEqual(serviceReturned, messageService);
            Assert.AreEqual(messageService, serviceSecondCall);
            _mockMessageServiceFactory.VerifyAllExpectations();
        }

        [Test]
        public void NewsServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var serviceReturned = new NewsService(new NewsQuery(_mockApiConnection.CoreConnection));

            _mockNewsServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(serviceReturned)
                .Repeat.Once();

            // Act
            var newsService = _serviceManager.NewsService;
            var serviceSecondCall = _serviceManager.NewsService;

            // Assert
            Assert.AreEqual(serviceReturned, newsService);
            Assert.AreEqual(newsService, serviceSecondCall);
            _mockNewsServiceFactory.VerifyAllExpectations();
        }

        [Test]
        public void SpreadMarketServicePropertyLazyLoadsTheServiceTheFirstTimeItsCalled()
        {
            // Arrange
            var serviceReturned = new SpreadMarketService(new SpreadMarketsQuery(_mockApiConnection.CoreConnection));

            _spreadMarketServiceFactory.Expect(x => x.Create(_mockApiConnection))
                .Return(serviceReturned)
                .Repeat.Once();

            // Act
            var service = _serviceManager.SpreadMarketService;
            var serviceSecondCall = _serviceManager.SpreadMarketService;

            // Assert
            Assert.AreEqual(serviceReturned, service);
            Assert.AreEqual(service, serviceSecondCall);
            _mockNewsServiceFactory.VerifyAllExpectations();
        }
    }
}
