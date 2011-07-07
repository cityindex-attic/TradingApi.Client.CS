using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class AccountInfoService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountInfoService));
        private readonly AccountInformationQuery _accountInformationQuery;

        internal AccountInfoService(AccountInformationQuery accountInformationQuery)
        {
            _accountInformationQuery = accountInformationQuery;
        }
        
        public AccountInformationResponseDTO GetClientAndTradingAccount()
        {
            Log.Info("Getting client and trading account.");
            return _accountInformationQuery.GetClientAndTradingAccount();
        }
    }
}