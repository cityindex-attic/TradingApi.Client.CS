using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.Services
{
    public class SpreadMarketServiceSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SpreadMarketServiceSample));

        public static void Run()
        {
            Log.Info("SpreadMarketService sample...");

            // Get the username and password
            string username = ConfigurationManager.AppSettings["TradingAccountCode"];
            string password = ConfigurationManager.AppSettings["Password"];

            // Get trading api base uri
            string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

            // Login
            CiApi.Instance.Login(username, password, tradingApiBaseUri);

            // Get account information
            var accountInfo = CiApi.Instance.ServiceManager.AccountInformationService.GetClientAndTradingAccount();

            // Search spread markets available to client, get back the 100 results:
            // 1) If query is empty the rest of the searchByMarketName and searchByMarketCode parameters are ignored
            var listSpreadMarkets = CiApi.Instance.ServiceManager.SpreadMarketService.ListSpreadMarkets("", true, true, accountInfo.ClientAccountId, 300);
            Log.Info("All markets");
            foreach (var market in listSpreadMarkets.Markets)
            {
                Log.Info("Market id: " + market.MarketId + ", Market name: " + market.Name);
            }
            
            Thread.Sleep(10000);

            // Logout
            CiApi.Instance.Logout();
        }
    }
}
