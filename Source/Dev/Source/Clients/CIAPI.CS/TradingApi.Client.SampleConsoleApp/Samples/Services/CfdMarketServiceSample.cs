using System;
using System.Configuration;
using System.Threading;
using Common.Logging;
using TradingApi.Client.Core.Exceptions;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.Services
{
    public class CfdMarketServiceSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CfdMarketServiceSample));

        public static void Run()
        {
            try
            {
                Log.Info("CfdMarketService sample...");

                string tradingAccountCode = ConfigurationManager.AppSettings["TradingAccountCode"];
                string password = ConfigurationManager.AppSettings["Password"];

                // Get trading api base uri
                string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

                // Login
                CiApi.Instance.Login(tradingAccountCode, password, tradingApiBaseUri);

                // Get account information
                var accountInfo = CiApi.Instance.ServiceManager.AccountInformationService.GetClientAndTradingAccount();

                // Search markets available to client, get back the 100 results:
                // 1) If query is empty the rest of the searchByMarketName and searchByMarketCode parameters are ignored
                var allCfdMarkets = CiApi.Instance.ServiceManager.CfdMarketService.ListCfdMarkets("", true, true, accountInfo.ClientAccountId, 300);
                Log.Info("All markets");
                foreach (var cfdMarket in allCfdMarkets.Markets)
                {
                    Log.Info("Market id: " + cfdMarket.MarketId + ", Market name: " + cfdMarket.Name);
                }
                
                // 2) Search markets by market name
                var cfdMarketsByMarketName = CiApi.Instance.ServiceManager.CfdMarketService.ListCfdMarkets("A", true, true, accountInfo.ClientAccountId, 100);
                Log.Info("Market search by name");
                foreach (var cfdMarket in cfdMarketsByMarketName.Markets)
                {
                    Log.Info("Market id: " + cfdMarket.MarketId + ", Market name: " + cfdMarket.Name);
                }

                // 3) Search markets by market code
                var cfdMarketsByMarketCode = CiApi.Instance.ServiceManager.CfdMarketService.ListCfdMarkets("CAD", false, true, accountInfo.ClientAccountId, 100);
                Log.Info("Market search by code");
                foreach (var cfdMarket in cfdMarketsByMarketCode.Markets)
                {
                    Log.Info("Market id: " + cfdMarket.MarketId + ", Market name: " + cfdMarket.Name);
                }

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
