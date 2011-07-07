using System;
using System.Collections.Generic;
using StreamingClient;
using TradingApi.Client.Framework.DTOs;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection
{
    public class LsGenericCityindexStreamingConnection : StreamingClient.Lightstreamer.LightStreamerClientConnectionBase, ILsCityindexStreamingConnection
    {
        public LsGenericCityindexStreamingConnection(Uri streamingUri, string userName, string sessionId)
            : base(streamingUri, userName, sessionId)
        {
        }

        public IStreamingListener<PriceDTO> BuildPriceListener(string topic)
        {
            return BuildListener<PriceDTO>(topic);
        }

        public IStreamingListener<PriceDTO> BuildPriceListener(List<string> topics)
        {
            return BuildListener<PriceDTO>(topics);
        }

        public IStreamingListener<NewsDTO> BuildNewsHeadlinesListener(string topic)
        {
            return BuildListener<NewsDTO>(topic);
        }
    }
}
