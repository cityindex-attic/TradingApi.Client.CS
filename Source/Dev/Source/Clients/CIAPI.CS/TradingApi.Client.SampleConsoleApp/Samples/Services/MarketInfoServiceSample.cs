using System;
using System.Configuration;
using System.Threading;
using Common.Logging;
using TradingApi.Client.Core.Exceptions;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.Services
{
    public class MarketInfoServiceSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MarketInfoServiceSample)); 

        public static void Run()
        {
            try
            {
                Log.Info("MarketInfoService sample...");

                // Get the username and password
                string username = ConfigurationManager.AppSettings["TradingAccountCode"];
                string password = ConfigurationManager.AppSettings["Password"];

                // Get trading api base uri
                string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

                // Login
                CiApi.Instance.Login(username, password, tradingApiBaseUri);

                // Get Market Info
                const int validMarketId = 400481134;
                var marketInfo = CiApi.Instance.ServiceManager.MarketInfoService.GetMarketInfo(validMarketId);

                // Log market name
                Log.Info("Market name: " + marketInfo.MarketInformation.Name);

                Thread.Sleep(10000);

                // Logout
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
