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
    public class SubscribeToPriceStreamSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SubscribeToPriceListStreamSample)); 

        public static void Run()
        {
            try
            {
                Log.Info("Subscribe to market price...");

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
                const int marketId = 400481134;
                CiApi.Instance.StreamingManager.Streams.PriceStream.SubscribeToMarketPrice(marketId);

                // Handle PricedChanged event
                CiApi.Instance.StreamingManager.Streams.PriceStream.PriceChanged += new PriceChangedEventHandler(PriceListener_PriceChanged);

                // Give sample time to get price events
                Thread.Sleep(TimeSpan.FromSeconds(10));

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

        private static void PriceListener_PriceChanged(object sender, MessageEventArgs<PriceDTO> e)
        {
            if (e.Data != null)
            {
                var priceDTOs = new List<PriceDTO>();
                var priceDTO = e.Data;
                priceDTOs.Add(priceDTO); //Its data property contains a typed DTO
                Console.WriteLine("Wall Street CFD price Changed: " + priceDTO.Bid);
            }
        }
    }
}
