using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using StreamingClient;
using TradingApi.Client.Framework.DTOs;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener
{
    public delegate void PriceChangedEventHandler(object sender, MessageEventArgs<PriceDTO> eventArgs);

    public class PriceStream
    {
        //Todo: filter on subset for subscriptions, if need to unsubsribe then start a new subscription
        //Instead of building more listeners, keep a store of the prices being subscribed to and add or remove 
        private static readonly ILog Log = LogManager.GetLogger(typeof(PriceStream));
        private const string PRICES_TOPIC = "PRICES.PRICE.";
        private readonly ILsCityindexStreamingConnection _lsCityindexStreamingConnection;
        private readonly List<IStreamingListener<PriceDTO>> _listeners = new List<IStreamingListener<PriceDTO>>();
        public event PriceChangedEventHandler PriceChanged;

        public PriceStream(ILsCityindexStreamingConnection lsCityindexStreamingConnection)
        {
            _lsCityindexStreamingConnection = lsCityindexStreamingConnection;
        }

        public List<IStreamingListener<PriceDTO>> Listeners
        {
            get { return _listeners; }
        }

        public void SubscribeToMarketPrice(int marketId)
        {
            Log.Info("Subscribing to market price for market id: " + marketId + ".");
            IStreamingListener<PriceDTO> priceListener = _lsCityindexStreamingConnection.BuildPriceListener(PRICES_TOPIC + marketId);
            priceListener.MessageReceived += new EventHandler<MessageEventArgs<PriceDTO>>(OnPriceListener_MessageReceived);
            priceListener.Start();
            _listeners.Add(priceListener);
        }

        public void SubscribeToMarketPriceList(List<int> marketIdList)
        {
            Log.Info("Subscribing to market prices.");
            var topics = marketIdList.Select(marketId => PRICES_TOPIC + marketId).ToList();
            IStreamingListener<PriceDTO> priceListener = _lsCityindexStreamingConnection.BuildPriceListener(topics);
            priceListener.MessageReceived += new EventHandler<MessageEventArgs<PriceDTO>>(OnPriceListener_MessageReceived);
            priceListener.Start();
            _listeners.Add(priceListener);
        }

        private void OnPriceListener_MessageReceived(object sender, MessageEventArgs<PriceDTO> eventArgs)
        {
            if (eventArgs.Data != null)
                PriceChanged(sender, eventArgs);
        }

        public void Unsubscribe()
        {
            Log.Debug("Unsubscribing to prices.");
            foreach (var priceListener in _listeners)
            {
                priceListener.Stop();
            }
        }
    }
}