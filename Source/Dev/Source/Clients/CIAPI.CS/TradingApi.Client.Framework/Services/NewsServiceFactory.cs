using System;
using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class NewsServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(NewsServiceFactory));

        public virtual NewsService Create(IApiConnection apiConnection)
        {
            try
            {
                Log.Debug("Creating News Service.");
                return new NewsService(new NewsQuery(apiConnection.CoreConnection));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}