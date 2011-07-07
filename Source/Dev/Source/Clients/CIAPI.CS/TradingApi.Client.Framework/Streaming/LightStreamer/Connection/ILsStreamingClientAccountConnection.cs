using StreamingClient;
using TradingApi.Client.Framework.DTOs;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection
{
    public interface ILsStreamingClientAccountConnection : IStreamingClient
    {
        IStreamingListener<OrderDTO> BuildOrderListener(string topic);
        IStreamingListener<ClientAccountMarginDTO> BuildClientAccountMarginListener(string topic);
        IStreamingListener<QuoteDTO> BuildQuoteListener(string topic);
    }
}