using System;
using System.Configuration;
using System.Threading;
using Common.Logging;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.Services
{
    public class OrderServiceSample
    {
        private static ILog Log = LogManager.GetLogger(typeof(OrderServiceSample));

        public static void Run()
        {
            Log.Info("OrderService sample...");

            // Get the username and password
            string username = ConfigurationManager.AppSettings["TradingAccountCode"];
            string password = ConfigurationManager.AppSettings["Password"];

            // Get trading api base uri
            string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

            // Login
            CiApi.Instance.Login(username, password, tradingApiBaseUri);

            // Get account Info
            int tradingAccountId = 0;
            foreach (var tradingAccountDTO in CiApi.Instance.ServiceManager.AccountInformationService.GetClientAndTradingAccount().TradingAccounts)
            {
                if(tradingAccountDTO.TradingAccountCode == username.ToUpper())
                    tradingAccountId = tradingAccountDTO.TradingAccountId;
            }

            if(tradingAccountId == 0)
                throw new Exception("Use a valid trading account for username.");

            // Get trading account
            var openPositionsList = CiApi.Instance.ServiceManager.OrderService.ListOpenPositions(tradingAccountId);

            // Log open positions count
            Log.Info("Open positions count: " + openPositionsList.OpenPositions.Count);

            // Display first open position
            if (openPositionsList.OpenPositions.Count > 0)
            {
                var firstOpenPosition = openPositionsList.OpenPositions[0];
                Log.Info("First open position: MarketId -" + firstOpenPosition.MarketId + ", Quantity: " + firstOpenPosition.Quantity);

                //Get single order
                var orderDto = CiApi.Instance.ServiceManager.OrderService.GetSingleOrder(firstOpenPosition.OrderId);
                Log.Info("Order price: " + orderDto.TradeOrder.Price + ", Quantity: " + orderDto.TradeOrder.Quantity);
            }

            // Get the last 50 orders in history for this trading account
            var orderHistoryList = CiApi.Instance.ServiceManager.OrderService.ListStopLimitOrderHistory(tradingAccountId, 50);
            int i = 1;
            foreach (var orderHistoryDTO in orderHistoryList.StopLimitOrderHistory)
            {
                Log.Info(i + ") Id: " + orderHistoryDTO.OrderId + ", Market: " + orderHistoryDTO.MarketName + ", last changed: " + orderHistoryDTO.LastChangedDateTimeUtc.Date);
                i++;
            }

            Thread.Sleep(10000);

            // Logout
            CiApi.Instance.Logout();
        }
    }
}
