using System;
using System.Configuration;
using System.Threading;
using Common.Logging;
using StreamingClient;
using TradingApi.Client.Core.Exceptions;
using TradingApi.Client.Framework.ApiFacade;
using TradingApi.Client.Framework.DTOs;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.SampleConsoleApp.Samples.Streams
{
    public class SubscribeToOrderStreamSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SubscribeToOrderStreamSample)); 

        public static void Run()
        {
            try
            {
                Log.Info("Subscribe to orders...");

                // Get the username and password
                string username = ConfigurationManager.AppSettings["TradingAccountCode"];
                string password = ConfigurationManager.AppSettings["Password"];
            
                // Set trading api base uri
                string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

                // Set lightstreamer url
                string lightstreamerUrl = ConfigurationManager.AppSettings["LightstreamerUrl"];

                // Login
                CiApi.Instance.Login(username, password, tradingApiBaseUri);

                // Set the streaming url
                CiApi.Instance.StreamingManager.StreamingUrl = lightstreamerUrl;
                
                // Subsrcibe to orders
                CiApi.Instance.StreamingManager.Streams.OrderStream.SubscribeToOrders();

                // Handle OrderChanged event
                CiApi.Instance.StreamingManager.Streams.OrderStream.OrderMessageRecieved += new OrderMessageRecievedEventHandler(OrderStream_OrderMessageRecieved);

                // Give sample time to get events
                Thread.Sleep(TimeSpan.FromSeconds(380));

                // Stop the stream
                CiApi.Instance.StreamingManager.Streams.OrderStream.Unsubscribe();

                // Logout will disconnect the streaming client
                CiApi.Instance.Logout();
            }
            catch (ApiCallException apiCallException)
            {
                Log.Error(apiCallException.Message);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                CiApi.Instance.Logout();
                throw;
            }
         }

        static void OrderStream_OrderMessageRecieved(object sender, MessageEventArgs<OrderDTO> eventArgs)
        {
            if (eventArgs.Data != null)
            {
                var orderDTO = eventArgs.Data;
                Console.WriteLine("Client account id: " + orderDTO.ClientAccountId + ", Order id: " + orderDTO.OrderId + ", Direction: " + orderDTO.Direction);
            }
        }
    }
}
