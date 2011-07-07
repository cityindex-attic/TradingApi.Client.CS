using Common.Logging;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class AccountInfoServiceFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountInfoServiceFactory));

        public virtual AccountInfoService Create(IApiConnection apiConnection)
        {
            Log.Info("Creating account information service.");
            return new AccountInfoService(new AccountInformationQuery(apiConnection.CoreConnection));
        }
    }
}