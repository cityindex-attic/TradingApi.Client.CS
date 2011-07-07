using System;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory
{
    public abstract class LsStreamingClientAccountConnectionFactory
    {
        public abstract ILsStreamingClientAccountConnection Create(Uri streamingAndAdapterUri, string username, string session);
    }
}