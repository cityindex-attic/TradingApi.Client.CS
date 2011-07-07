using System;
using System.Collections.Generic;
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
    public class SubscribeToPriceListStreamSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SubscribeToPriceListStreamSample)); 
        
        public static void Run()
        {
            try
            {
                Log.Info("Subscribe to market price list...");

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

                // Subscribe to prices with valid market id
                const int validMarketIdOne = 400481134;
                const int validMarketIdTwo = 400481148;
                var marketIdList = new List<int>() { validMarketIdOne, validMarketIdTwo};

                CiApi.Instance.StreamingManager.Streams.PriceStream.SubscribeToMarketPriceList(marketIdList);

                // Handle PricedChanged event
                CiApi.Instance.StreamingManager.Streams.PriceStream.PriceChanged += new PriceChangedEventHandler(PriceStream_PriceChanged);

                // Give it time to get price events
                Thread.Sleep(TimeSpan.FromSeconds(30));

                // Stop the stream
                CiApi.Instance.StreamingManager.Streams.PriceStream.Unsubscribe();

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

        private static void PriceStream_PriceChanged(object sender, MessageEventArgs<PriceDTO> e)
        {
            if (e.Data != null)
            {
                var priceDTO = e.Data;
                Console.WriteLine("MarketId: " + priceDTO.MarketId + ", Bid price: " + priceDTO.Bid);
            }
        }
    }
}
