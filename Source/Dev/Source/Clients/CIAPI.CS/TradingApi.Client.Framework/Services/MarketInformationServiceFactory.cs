using System;
using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class MarketInformationServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MarketInformationServiceFactory));

        public virtual MarketInformationService Create(IApiConnection apiConnection)
        {
            try
            {
                Log.Debug("Creating market information service");
                return new MarketInformationService(new MarketInformationQuery(apiConnection.CoreConnection));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
            
            // Alternatively could cache at the actual service method call i.e use an enum
            // new MarketServiceFactory().Create().GetMarketInformation(cableMarketId, Cache.On);
        }
    }
}
