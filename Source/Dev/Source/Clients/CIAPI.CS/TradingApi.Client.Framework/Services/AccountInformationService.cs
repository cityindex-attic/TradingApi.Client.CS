using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class AccountInformationService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountInformationService));
        private readonly AccountInformationQuery _accountInformationQuery;

        internal AccountInformationService(AccountInformationQuery accountInformationQuery)
        {
            _accountInformationQuery = accountInformationQuery;
        }
        
        public AccountInformationResponseDTO GetClientAndTradingAccount()
        {
            Log.Debug("Getting client and trading account.");
            return _accountInformationQuery.GetClientAndTradingAccount();
        }
    }
}