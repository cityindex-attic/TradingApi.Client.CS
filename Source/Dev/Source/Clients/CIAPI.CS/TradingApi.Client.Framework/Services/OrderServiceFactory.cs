using System;
using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class OrderServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderServiceFactory));

        public virtual OrderService Create(IApiConnection apiConnection)
        {
            try
            {
                Log.Debug("Creating order service");
                return new OrderService(new OpenPositionsQuery(apiConnection.CoreConnection), new OrderQuery(apiConnection.CoreConnection), new StopLimitOrderHistoryQuery(apiConnection.CoreConnection));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}