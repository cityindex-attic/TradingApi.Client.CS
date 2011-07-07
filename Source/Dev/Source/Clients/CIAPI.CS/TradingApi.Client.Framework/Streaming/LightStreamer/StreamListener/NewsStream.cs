using System;
using System.Collections;
using System.Collections.Generic;
using Common.Logging;
using StreamingClient;
using TradingApi.Client.Framework.DTOs;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener
{
    public delegate void NewsMessageHandler(object sender, MessageEventArgs<NewsDTO> newsDTO);

    public class NewsStream
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(NewsStream));
        private const string NEWS_ADAPTER = "NEWS.";
        private readonly ILsCityindexStreamingConnection _lsCityindexStreamingConnection;
        private readonly List<IStreamingListener<NewsDTO>> _listeners = new List<IStreamingListener<NewsDTO>>();
        public event NewsMessageHandler NewsMessageRecieved;

        public NewsStream(ILsCityindexStreamingConnection lsCityindexStreamingConnection)
        {
            _lsCityindexStreamingConnection = lsCityindexStreamingConnection;
        }

        public List<IStreamingListener<NewsDTO>> Listeners
        {
            get { return _listeners; }
        }

        public void SubscribeToNewsHeadlinesByRegion(string region)
        {
            Log.Info("Subscribing to news headlines for region: " + region + ".");
            IStreamingListener<NewsDTO> newsListener = _lsCityindexStreamingConnection.BuildNewsHeadlinesListener(NEWS_ADAPTER + "HEADLINES." + region);
            //Todo: test for event handler
            newsListener.MessageReceived +=new EventHandler<MessageEventArgs<NewsDTO>>(NewsListener_MessageReceived);
            newsListener.Start();
            _listeners.Add(newsListener);
        }

        private void NewsListener_MessageReceived(object sender, MessageEventArgs<NewsDTO> eventArgs)
        {
            if (eventArgs.Data != null)
                NewsMessageRecieved(sender, eventArgs);
        }

        public void Unsubscribe()
        {
            Log.Debug("Unsubscribing to news.");
            foreach (var newsListener in _listeners)
            {
                newsListener.Stop();
            }
        }
    }
}