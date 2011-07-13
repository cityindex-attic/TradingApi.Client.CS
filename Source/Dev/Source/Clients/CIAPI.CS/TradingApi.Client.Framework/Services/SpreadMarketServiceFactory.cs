using System;
using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class SpreadMarketServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SpreadMarketServiceFactory));

        public virtual SpreadMarketService Create(IApiConnection apiConnection)
        {
            try
            {
                return new SpreadMarketService(new SpreadMarketsQuery(apiConnection.CoreConnection));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}