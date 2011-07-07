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
    public class SubscribeToNewsStreamSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SubscribeToNewsStreamSample)); 

        public static void Run()
        {
            try
            {
                Log.Info("Subscribe to news stream...");

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
                
                // Subscribe to the news headline by a region
                CiApi.Instance.StreamingManager.Streams.NewsStream.SubscribeToNewsHeadlinesByRegion("US");

                // Handle news changed event
                CiApi.Instance.StreamingManager.Streams.NewsStream.NewsMessageRecieved +=new NewsMessageHandler(NewsStream_NewMessage);

                // Give sample time to get news events
                Thread.Sleep(TimeSpan.FromSeconds(60));

                // Stop the stream
                CiApi.Instance.StreamingManager.Streams.NewsStream.Unsubscribe();

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

        private static void NewsStream_NewMessage(object sender, MessageEventArgs<NewsDTO> eventArgs)
        {
            if (eventArgs.Data != null)
            {
                var newsDTO = eventArgs.Data;
                Console.WriteLine("News headline: " + newsDTO.Headline);
            }
        }
    }
}
