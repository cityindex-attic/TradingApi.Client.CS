using System;
using System.Configuration;
using System.Threading;
using Common.Logging;
using TradingApi.Client.Core.Exceptions;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.Services
{
    public class AccountInformationServiceSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AccountInformationServiceSample));

        public static void Run()
        {
            try
            {
                Log.Info("AccountInformationService sample...");

                // Get the username and password
                string username = ConfigurationManager.AppSettings["TradingAccountCode"];
                string password = ConfigurationManager.AppSettings["Password"];

                // Set trading api base uri
                string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

                // Login
                CiApi.Instance.Login(username, password, tradingApiBaseUri);

                // Get account Info
                var accountInfo = CiApi.Instance.ServiceManager.AccountInformationService.GetClientAndTradingAccount();

                // Get trading account info
                var tradingAccountsList = accountInfo.TradingAccounts;
                var tradingAccount = tradingAccountsList[0];

                // Log client details
                Log.Info("Client account id: " + accountInfo.ClientAccountId);
                Log.Info("Client account currency: " + accountInfo.ClientAccountCurrency);
                Log.Info("Number of trading accounts: " + accountInfo.TradingAccounts.Count);

                if(tradingAccount != null)
                    Log.Info("Trading account type: " + tradingAccount.TradingAccountType);

                Thread.Sleep(10000);

                CiApi.Instance.Logout();
            }
            catch (ApiCallException apiCallException)
            {
                Log.Error(apiCallException.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
