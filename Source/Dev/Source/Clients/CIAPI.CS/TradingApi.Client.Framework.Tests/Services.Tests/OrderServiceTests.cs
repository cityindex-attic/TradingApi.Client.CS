using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private Connection _mockConnection;
        private OpenPositionsQuery _mockOpenPositionsQuery;
        private OrderQuery _mockOrderQuery;
        private OrderService _orderService;
        private StopLimitOrderHistoryQuery _mockStopLimitOrderHistoryQuery;

        [SetUp]
        public void Setup()
        {
            _mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
            _mockOpenPositionsQuery = MockRepository.GenerateMock<OpenPositionsQuery>(_mockConnection);
            _mockOrderQuery = MockRepository.GenerateMock<OrderQuery>(_mockConnection);
            _mockStopLimitOrderHistoryQuery = MockRepository.GenerateMock<StopLimitOrderHistoryQuery>(_mockConnection);

            _orderService = new OrderService(_mockOpenPositionsQuery, _mockOrderQuery, _mockStopLimitOrderHistoryQuery);
        }

        [Test]
        public void ListOpenPositionsCallsTheCorrectMethodFromTheUnderlyingOpenPositionsQueryClass()
        {
            //Arrange
            const int tradingAccountId = 999;

            _mockOpenPositionsQuery.Expect(x => x.ListOpenPositions(tradingAccountId))
                .Return(new ListOpenPositionsResponseDTO());

            //Act
            var response = _orderService.ListOpenPositions(tradingAccountId);

            //Assert
            Assert.IsInstanceOfType(typeof(ListOpenPositionsResponseDTO), response);
            _mockOpenPositionsQuery.VerifyAllExpectations();
        }

        [Test]
        public void GetOpenPositionsCallsTheCorrectMethodFromTheUnderlyingOpenPositionsQueryClass()
        {
            //Arrange
            const int orderId = 999;

            _mockOpenPositionsQuery.Expect(x => x.GetOpenPosition(orderId))
                .Return(new GetOpenPositionResponseDTO());

            //Act
            var response = _orderService.GetOpenPosition(orderId);

            //Assert
            Assert.IsInstanceOfType(typeof(GetOpenPositionResponseDTO), response);
            _mockOpenPositionsQuery.VerifyAllExpectations();
        }

        [Test]
        public void GetSingleOrderCallsTheCorrectMethodFromTheUnderlyingOrderQueryClass()
        {
            //Arrange
            const int orderId = 999;

            _mockOrderQuery.Expect(x => x.GetSingleOrder(orderId))
                .Return(new GetOrderResponseDTO());

            //Act
            var response = _orderService.GetSingleOrder(orderId);

            //Assert
            Assert.IsInstanceOfType(typeof(GetOrderResponseDTO), response);
            _mockOrderQuery.VerifyAllExpectations();
        }

        [Test]
        public void ListOrderHistoryCallsTheCorrectMethodFromTheUnderlyingStopLimitOrderHistoryQueryClass()
        {
            //Arrange
            const int tradingAccountId = 999;
            const int maxResults = 200;

            _mockStopLimitOrderHistoryQuery.Expect(x => x.ListStopLimitOrderHistory(tradingAccountId, maxResults))
                .Return(new ListStopLimitOrderHistoryResponseDTO());

            //Act
            var response = _orderService.ListOrderHistory(tradingAccountId, maxResults);

            //Assert
            Assert.IsInstanceOfType(typeof(ListStopLimitOrderHistoryResponseDTO), response);
            _mockOrderQuery.VerifyAllExpectations();
        }
    }
}
