using System;
using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class CfdMarketServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CfdMarketServiceFactory));

        public virtual CfdMarketService Create(IApiConnection apiConnection)
        {
            Log.Info("Creating cfd market service");
            return new CfdMarketService(new CfdMarketQuery(apiConnection.CoreConnection));
        }
    }
}