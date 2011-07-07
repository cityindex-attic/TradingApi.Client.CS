using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class OrderService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderService));
        private OpenPositionsQuery _openPositionsQuery;
        private OrderQuery _orderQuery;
        private StopLimitOrderHistoryQuery _stopLimitOrderHistoryQuery;

        internal OrderService(OpenPositionsQuery openPositionsQuery, OrderQuery orderQuery, StopLimitOrderHistoryQuery stopLimitOrderHistoryQuery)
        {
            _openPositionsQuery = openPositionsQuery;
            _orderQuery = orderQuery;
            _stopLimitOrderHistoryQuery = stopLimitOrderHistoryQuery;
        }

        public ListOpenPositionsResponseDTO ListOpenPositions(int tradingAccountId)
        {
            Log.DebugFormat("TradingAccountId: {0}.", tradingAccountId);
            return _openPositionsQuery.ListOpenPositions(tradingAccountId);
        }

        public GetOpenPositionResponseDTO GetOpenPosition(int orderId)
        {
            return _openPositionsQuery.GetOpenPosition(orderId);
        }

        public GetOrderResponseDTO GetSingleOrder(int orderId)
        {
            return _orderQuery.GetSingleOrder(orderId);
        }

        public ListStopLimitOrderHistoryResponseDTO ListOrderHistory(int tradingAccountId, int maxResults)
        {
            return _stopLimitOrderHistoryQuery.ListStopLimitOrderHistory(tradingAccountId, maxResults);
        }
    }
}