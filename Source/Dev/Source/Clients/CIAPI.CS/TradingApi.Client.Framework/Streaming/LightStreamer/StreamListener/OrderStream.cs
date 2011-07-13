using System;
using System.Collections.Generic;
using Common.Logging;
using StreamingClient;
using TradingApi.Client.Framework.DTOs;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener
{
    public delegate void OrderMessageRecievedEventHandler(object sender, MessageEventArgs<OrderDTO> eventArgs);

    public class OrderStream
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderStream));
        private readonly ILsStreamingClientAccountConnection _lsCityindexStreamingClientConnection;
        private readonly List<IStreamingListener<OrderDTO>> _orderListeners = new List<IStreamingListener<OrderDTO>>();
        public event OrderMessageRecievedEventHandler OrderMessageRecieved;

        public OrderStream(ILsStreamingClientAccountConnection lsCityindexStreamingClientConnection)
        {
            _lsCityindexStreamingClientConnection = lsCityindexStreamingClientConnection;
        }

        public List<IStreamingListener<OrderDTO>>  Listeners
        {
            get { return _orderListeners; }
        }

        public void SubscribeToOrders()
        {
            Log.Info("Subscribing to orders.");
            var orderListener = _lsCityindexStreamingClientConnection.BuildOrderListener("ORDERS");
            orderListener.MessageReceived += new EventHandler<MessageEventArgs<OrderDTO>>(OnOrderListener_MessageReceived);
            orderListener.Start();
            _orderListeners.Add(orderListener);
        }

        private void OnOrderListener_MessageReceived(object sender, MessageEventArgs<OrderDTO> e)
        {
            if(e.Data != null)
                OrderMessageRecieved(sender, e);
        }

        public void Unsubscribe()
        {
            Log.Debug("Unsubscribing to orders.");
            foreach (var listener in _orderListeners)
            {
                listener.Stop();
            }
        }
    }
}