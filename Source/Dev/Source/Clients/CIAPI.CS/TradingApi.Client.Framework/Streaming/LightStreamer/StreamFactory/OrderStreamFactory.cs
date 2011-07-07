using System;
using Common.Logging;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.StreamFactory
{
    public class OrderStreamFactory : IOrderStreamFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderStreamFactory));

        public OrderStream Create(ILsStreamingClientAccountConnection lsCityindexStreamingClientConnection)
        {
            try
            {
                Log.Info("Creating order stream listener.");

                var orderStream = new OrderStream(lsCityindexStreamingClientConnection);

                return orderStream;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}