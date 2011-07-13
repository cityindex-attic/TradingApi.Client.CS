using NUnit.Framework;
using RESTWebServicesDTO.Request;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;
using ListOpenPositionsResponseDTO = RESTWebServicesDTO.Response.ListOpenPositionsResponseDTO;
using ListStopLimitOrderHistoryResponseDTO = RESTWebServicesDTO.Response.ListStopLimitOrderHistoryResponseDTO;

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
        private NewStopLimitOrderPlacer _mockNewStopLimitOrderPlacer;
        private NewTradeOrderPlacer _mockNewTradeOrderPlacer;
        private CancelOrderPlacer _mockCancelOrderPlacer;
        private ActiveStopLimitOrderQuery _mockActiveStopLimitOrderQuery;
        private TradeHistoryQuery _mockTradeHistoryQuery;

        [SetUp]
        public void Setup()
        {
            _mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
            _mockOpenPositionsQuery = MockRepository.GenerateMock<OpenPositionsQuery>(_mockConnection);
            _mockOrderQuery = MockRepository.GenerateMock<OrderQuery>(_mockConnection);
            _mockStopLimitOrderHistoryQuery = MockRepository.GenerateMock<StopLimitOrderHistoryQuery>(_mockConnection);
            _mockNewStopLimitOrderPlacer = MockRepository.GenerateMock<NewStopLimitOrderPlacer>(_mockConnection);
            _mockNewTradeOrderPlacer = MockRepository.GenerateMock<NewTradeOrderPlacer>(_mockConnection);
            _mockCancelOrderPlacer = MockRepository.GenerateMock<CancelOrderPlacer>(_mockConnection);
            _mockActiveStopLimitOrderQuery = MockRepository.GenerateMock<ActiveStopLimitOrderQuery>(_mockConnection);
            _mockTradeHistoryQuery = MockRepository.GenerateMock<TradeHistoryQuery>(_mockConnection);

            _orderService = new OrderService(_mockOpenPositionsQuery, _mockOrderQuery, _mockStopLimitOrderHistoryQuery, _mockNewStopLimitOrderPlacer, _mockNewTradeOrderPlacer, _mockCancelOrderPlacer, _mockActiveStopLimitOrderQuery, _mockTradeHistoryQuery);
        }

        [Test]
        public void ListOpenPositionsCallsTheCorrectMethodFromTheUnderlyingCore()
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
        public void GetOpenPositionsCallsTheCorrectMethodFromTheUnderlyingCore()
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
        public void GetSingleOrderCallsTheCorrectMethodFromTheUnderlyingCore()
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
        public void ListStopLimitOrderHistoryCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const int tradingAccountId = 999;
            const int maxResults = 200;

            _mockStopLimitOrderHistoryQuery.Expect(x => x.ListStopLimitOrderHistory(tradingAccountId, maxResults))
                .Return(new ListStopLimitOrderHistoryResponseDTO());

            //Act
            var response = _orderService.ListStopLimitOrderHistory(tradingAccountId, maxResults);

            //Assert
            Assert.IsInstanceOfType(typeof(ListStopLimitOrderHistoryResponseDTO), response);
            _mockStopLimitOrderHistoryQuery.VerifyAllExpectations();
        }

        [Test]
        public void NewStopLimitOrderCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            var newStopLimitOrderRequestDTO = new NewStopLimitOrderRequestDTO();
            
            _mockNewStopLimitOrderPlacer.Expect(x => x.NewStopLimitOrder(newStopLimitOrderRequestDTO))
                .Return(new ApiTradeOrderResponseDTO());

            //Act
            var response = _orderService.NewStopLimitOrder(newStopLimitOrderRequestDTO);

            //Assert
            Assert.IsInstanceOfType(typeof(ApiTradeOrderResponseDTO), response);
            _mockNewStopLimitOrderPlacer.VerifyAllExpectations();
        }

        [Test]
        public void NewTradeOrderCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            var newTradeOrderRequestDTO = new NewTradeOrderRequestDTO();

            _mockNewTradeOrderPlacer.Expect(x => x.NewTradeOrder(newTradeOrderRequestDTO))
                .Return(new ApiTradeOrderResponseDTO());

            //Act
            var response = _orderService.NewTradeOrder(newTradeOrderRequestDTO);

            //Assert
            Assert.IsInstanceOfType(typeof(ApiTradeOrderResponseDTO), response);
            _mockNewTradeOrderPlacer.VerifyAllExpectations();
        }

        [Test]
        public void CancelOrderCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            var cancelOrderRequestDTO = new CancelOrderRequestDTO();

            _mockCancelOrderPlacer.Expect(x => x.CancelOrder(cancelOrderRequestDTO))
                .Return(new ApiTradeOrderResponseDTO());

            //Act
            var response = _orderService.CancelOrder(cancelOrderRequestDTO);

            //Assert
            Assert.IsInstanceOfType(typeof(ApiTradeOrderResponseDTO), response);
            _mockCancelOrderPlacer.VerifyAllExpectations();
        }

        [Test]
        public void ListActiveStopLimitOrdersCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const int tradingAccountId = 1;

            _mockActiveStopLimitOrderQuery.Expect(x => x.ListActiveStopLimitOrders(tradingAccountId))
                .Return(new ListActiveStopLimitOrderResponseDTO());

            //Act
            var response = _orderService.ListActiveStopLimitOrders(tradingAccountId);

            //Assert
            Assert.IsInstanceOfType(typeof(ListActiveStopLimitOrderResponseDTO), response);
            _mockActiveStopLimitOrderQuery.VerifyAllExpectations();
        }

        [Test]
        public void GetActiveStopLimitOrderCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const int orderId = 1;

            _mockActiveStopLimitOrderQuery.Expect(x => x.GetActiveStopLimitOrder(orderId))
                .Return(new GetActiveStopLimitOrderResponseDTO());

            //Act
            var response = _orderService.GetActiveStopLimitOrder(orderId);

            //Assert
            Assert.IsInstanceOfType(typeof(GetActiveStopLimitOrderResponseDTO), response);
            _mockActiveStopLimitOrderQuery.VerifyAllExpectations();
        }

        [Test]
        public void ListTradeHistoryCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const int tradingAccountId = 1;
            const int maxResults = 2;
            _mockTradeHistoryQuery.Expect(x => x.ListTradeHistory(tradingAccountId, maxResults))
                .Return(new ListTradeHistoryResponseDTO());

            //Act
            var response = _orderService.ListTradeHistory(tradingAccountId, maxResults);

            //Assert
            Assert.IsInstanceOfType(typeof(ListTradeHistoryResponseDTO), response);
            _mockTradeHistoryQuery.VerifyAllExpectations();
        }
    }
}
