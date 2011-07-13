using System;
using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class MessageServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MessageServiceFactory));

        public virtual MessageService Create(IApiConnection apiConnection)
        {
            try
            {
                Log.Debug("Creating Message Service.");
                return new MessageService(new MessageLookupQuery(apiConnection.CoreConnection));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}