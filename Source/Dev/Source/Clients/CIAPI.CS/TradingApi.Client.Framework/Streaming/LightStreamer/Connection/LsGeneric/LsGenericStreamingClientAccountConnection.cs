using System;
using System.Collections.Generic;
using StreamingClient;
using TradingApi.Client.Framework.DTOs;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection
{
    internal class LsGenericStreamingClientAccountConnection : StreamingClient.Lightstreamer.LightStreamerClientConnectionBase, ILsStreamingClientAccountConnection
    {
        public LsGenericStreamingClientAccountConnection(Uri streamingUri, string userName, string sessionId)
            : base(streamingUri, userName, sessionId)
        {
        }

        public IStreamingListener<ClientAccountMarginDTO> BuildClientAccountMarginListener(string topic)
        {
            return BuildListener<ClientAccountMarginDTO>(topic);
        }

        public IStreamingListener<QuoteDTO> BuildQuoteListener(string topic)
        {
            return BuildListener<QuoteDTO>(topic);
        }

        public IStreamingListener<OrderDTO> BuildOrderListener(string topic)
        {
            return BuildListener<OrderDTO>(topic);
        }
    }
}
