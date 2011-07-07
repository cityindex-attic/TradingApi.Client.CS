using System;
using System.Configuration;
using System.Threading;
using Common.Logging;
using RESTWebServicesDTO.Response;
using StreamingClient;
using TradingApi.Client.Core.Exceptions;
using TradingApi.Client.Framework.ApiFacade;
using TradingApi.Client.Framework.DTOs;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.SampleConsoleApp.Samples.Streams
{
    public class SubscribeToMultipleStreams
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SubscribeToMultipleStreams)); 

        public static void Run()
        {
            try
            {
                Log.Info("Subscribe to multiple streams...");

                // Get the username and password
                string username = ConfigurationManager.AppSettings["TradingAccountCode"];
                string password = ConfigurationManager.AppSettings["Password"];
               
                // Set trading api base uri
                string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

                // Set lightstreamer url
                string lightstreamerUrl = ConfigurationManager.AppSettings["LightstreamerUrl"];

                // Login
                var logonResponse =  CiApi.Instance.Login(username, password, tradingApiBaseUri);

                // Set the streaming url
                CiApi.Instance.StreamingManager.StreamingUrl = lightstreamerUrl;

                // Subscribe to prices with valid market id
                const int validMarketId = 400481134;

                // Subscribe to prices
                CiApi.Instance.StreamingManager.Streams.PriceStream.SubscribeToMarketPrice(validMarketId);
                CiApi.Instance.StreamingManager.Streams.PriceStream.PriceChanged += new PriceChangedEventHandler(PriceStream_PriceChanged);

                // Subscribe to another price listener on same connection 
                CiApi.Instance.StreamingManager.Streams.PriceStream.SubscribeToMarketPrice(400485556);
                CiApi.Instance.StreamingManager.Streams.PriceStream.PriceChanged += new PriceChangedEventHandler(PriceStream_PriceChanged);
                
                // Subscribe to prices on another connection
                SubscribeToPricesWithCustomFactory(username, lightstreamerUrl, logonResponse, validMarketId);

                // Subscribe to orders
                CiApi.Instance.StreamingManager.Streams.OrderStream.SubscribeToOrders();
                CiApi.Instance.StreamingManager.Streams.OrderStream.OrderMessageRecieved +=new OrderMessageRecievedEventHandler(OrderStream_OrderMessageRecieved);
                
                // Give it time to get price events
                Thread.Sleep(TimeSpan.FromSeconds(300));

                // Stop the streams
                CiApi.Instance.StreamingManager.Streams.PriceStream.Unsubscribe();
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
            }
         }

        private static void SubscribeToPricesWithCustomFactory(string username, string lightstreamerUrl, ApiLogOnResponseDTO logonResponse, int validMarketId)
        {
            var cityindexStreamingConnection = new DefaultCityindexStreamingConnectionFactory().Create(new Uri(lightstreamerUrl + "/CITYINDEXSTREAMING"), username, logonResponse.Session);
            cityindexStreamingConnection.Connect();
            PriceStream priceStream = new PriceStream(cityindexStreamingConnection);
            priceStream.SubscribeToMarketPrice(validMarketId);
            priceStream.PriceChanged += new PriceChangedEventHandler(CustomPriceStream_PriceChanged);
        }

        private static void CustomPriceStream_PriceChanged(object sender, MessageEventArgs<PriceDTO> e)
        {
            if (e.Data != null)
            {
                var priceDTO = e.Data;
                Console.WriteLine("Connection 2) MarketId: " + priceDTO.MarketId + ", Bid price: " + priceDTO.Bid);
            }
        }

        private static void OrderStream_OrderMessageRecieved(object sender, MessageEventArgs<OrderDTO> eventargs)
        {
            if (eventargs.Data != null)
            {
                var orderDTO = eventargs.Data;
                Console.WriteLine("Client account id: " + orderDTO.ClientAccountId + ", Order id: " + orderDTO.OrderId + ", Direction: " + orderDTO.Direction);
            }
        }

        private static void PriceStream_PriceChanged(object sender, MessageEventArgs<PriceDTO> e)
        {
            if (e.Data != null)
            {
                var priceDTO = e.Data;
                Console.WriteLine("Connection 1) MarketId: " + priceDTO.MarketId + ", Bid price: " + priceDTO.Bid);
            }
        }
    }
}
