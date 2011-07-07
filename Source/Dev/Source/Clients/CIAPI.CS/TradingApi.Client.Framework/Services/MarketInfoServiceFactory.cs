using System;
using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class MarketInfoServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MarketInfoServiceFactory));

        public virtual MarketInfoService Create(IApiConnection apiConnection)
        {
            try
            {
                Log.Debug("Creating market information service");
                return new MarketInfoService(new MarketInformationQuery(apiConnection.CoreConnection));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
            
            // Alternatively could cache at the actual service method call i.e use an enum
            // new MarketServiceFactory().Create().GetMarketInfo(cableMarketId, Cache.On);
        }
    }
}
