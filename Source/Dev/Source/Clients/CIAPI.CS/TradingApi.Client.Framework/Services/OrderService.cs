using System;
using Common.Logging;
using RESTWebServicesDTO.Request;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class OrderService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderService));
        private readonly OpenPositionsQuery _openPositionsQuery;
        private readonly OrderQuery _orderQuery;
        private readonly StopLimitOrderHistoryQuery _stopLimitOrderHistoryQuery;
        private readonly NewStopLimitOrderPlacer _newStopLimitOrderPlacer;
        private readonly NewTradeOrderPlacer _newTradeOrderPlacer;
        private readonly CancelOrderPlacer _cancelOrderPlacer;
        private readonly ActiveStopLimitOrderQuery _activeStopLimitOrderQuery;
        private readonly TradeHistoryQuery _tradeHistoryQuery;

        internal OrderService(OpenPositionsQuery openPositionsQuery, OrderQuery orderQuery, StopLimitOrderHistoryQuery stopLimitOrderHistoryQuery, NewStopLimitOrderPlacer newStopLimitOrderPlacer, NewTradeOrderPlacer newTradeOrderPlacer, CancelOrderPlacer cancelOrderPlacer, ActiveStopLimitOrderQuery activeStopLimitOrderQuery, TradeHistoryQuery tradeHistoryQuery)
        {
            _openPositionsQuery = openPositionsQuery;
            _orderQuery = orderQuery;
            _stopLimitOrderHistoryQuery = stopLimitOrderHistoryQuery;
            _newStopLimitOrderPlacer = newStopLimitOrderPlacer;
            _newTradeOrderPlacer = newTradeOrderPlacer;
            _cancelOrderPlacer = cancelOrderPlacer;
            _activeStopLimitOrderQuery = activeStopLimitOrderQuery;
            _tradeHistoryQuery = tradeHistoryQuery;
        }

        public ListOpenPositionsResponseDTO ListOpenPositions(int tradingAccountId)
        {
            Log.DebugFormat("TradingAccountId: {0}.", tradingAccountId);
            return _openPositionsQuery.ListOpenPositions(tradingAccountId);
        }

        public GetOpenPositionResponseDTO GetOpenPosition(int orderId)
        {
            Log.DebugFormat("orderId: {0}.", orderId);
            return _openPositionsQuery.GetOpenPosition(orderId);
        }

        public GetOrderResponseDTO GetSingleOrder(int orderId)
        {
            Log.DebugFormat("orderId: {0}.", orderId);
            return _orderQuery.GetSingleOrder(orderId);
        }

        public ListStopLimitOrderHistoryResponseDTO ListStopLimitOrderHistory(int tradingAccountId, int maxResults)
        {
            Log.DebugFormat("tradingAccountId: {0}, maxResults: {1}", tradingAccountId, maxResults);
            return _stopLimitOrderHistoryQuery.ListStopLimitOrderHistory(tradingAccountId, maxResults);
        }

        public ApiTradeOrderResponseDTO NewStopLimitOrder(NewStopLimitOrderRequestDTO newStopLimitOrderRequestDTO)
        {
            return _newStopLimitOrderPlacer.NewStopLimitOrder(newStopLimitOrderRequestDTO);
        }

        public ApiTradeOrderResponseDTO NewTradeOrder(NewTradeOrderRequestDTO newTradeOrderRequestDTO)
        {
            return _newTradeOrderPlacer.NewTradeOrder(newTradeOrderRequestDTO);
        }

        public ApiTradeOrderResponseDTO CancelOrder(CancelOrderRequestDTO cancelOrderRequestDTO)
        {
            return _cancelOrderPlacer.CancelOrder(cancelOrderRequestDTO);
        }

        public ListActiveStopLimitOrderResponseDTO ListActiveStopLimitOrders(int tradingAccountId)
        {
            Log.DebugFormat("tradingAccountId: {0}.", tradingAccountId);
            return _activeStopLimitOrderQuery.ListActiveStopLimitOrders(tradingAccountId);
        }

        public GetActiveStopLimitOrderResponseDTO GetActiveStopLimitOrder(int orderId)
        {
            Log.DebugFormat("orderId: {0}.", orderId);
            return _activeStopLimitOrderQuery.GetActiveStopLimitOrder(orderId);
        }

        public ListTradeHistoryResponseDTO ListTradeHistory(int tradingAccountId, int maxResults)
        {
            return _tradeHistoryQuery.ListTradeHistory(tradingAccountId, maxResults);
        }
    }
}