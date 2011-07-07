using System;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory
{
    public abstract class LsCityindexStreamingConnectionFactory
    {
        public abstract ILsCityindexStreamingConnection Create(Uri streamingAndAdapterUri, string username, string session);
    }
}