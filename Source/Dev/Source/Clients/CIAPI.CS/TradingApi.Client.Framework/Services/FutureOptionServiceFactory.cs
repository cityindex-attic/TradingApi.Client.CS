using System;
using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class FutureOptionServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(FutureOptionServiceFactory));

        public virtual FutureOptionService Create(IApiConnection apiConnection)
        {
            try
            {
                Log.Debug("Creating future option service.");
                return new FutureOptionService(new FutureOptionPlacer(apiConnection.CoreConnection));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}