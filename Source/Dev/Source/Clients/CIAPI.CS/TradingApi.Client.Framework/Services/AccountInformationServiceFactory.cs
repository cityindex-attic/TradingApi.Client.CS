using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class AccountInformationServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountInformationServiceFactory));

        public virtual AccountInformationService Create(IApiConnection apiConnection)
        {
            Log.Info("Creating account information service.");
            return new AccountInformationService(new AccountInformationQuery(apiConnection.CoreConnection));
        }
    }
}