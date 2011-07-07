using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.StreamFactory
{
    public interface INewsStreamFactory
    {
        NewsStream Create(ILsCityindexStreamingConnection lsCityindexStreamingConnection);
    }
}