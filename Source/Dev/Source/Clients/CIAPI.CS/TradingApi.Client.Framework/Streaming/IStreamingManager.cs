using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory;

namespace TradingApi.Client.Framework.Streaming
{
    public interface IStreamingManager
    {
        LightStreamerConnectionManager LightStreamerConnectionManager { get; }
        Streams Streams { get; }
        string StreamingUrl { get; set; }
        void Disconnect();
    }
}