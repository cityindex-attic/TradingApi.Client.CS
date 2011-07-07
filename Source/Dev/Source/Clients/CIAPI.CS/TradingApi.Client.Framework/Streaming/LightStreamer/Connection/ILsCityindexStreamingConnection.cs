using System.Collections.Generic;
using StreamingClient;
using TradingApi.Client.Framework.DTOs;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection
{
    public interface ILsCityindexStreamingConnection : IStreamingClient
    {
        IStreamingListener<PriceDTO> BuildPriceListener(string topic);
        IStreamingListener<PriceDTO> BuildPriceListener(List<string> topics);
        IStreamingListener<NewsDTO> BuildNewsHeadlinesListener(string topic);
    }
}
