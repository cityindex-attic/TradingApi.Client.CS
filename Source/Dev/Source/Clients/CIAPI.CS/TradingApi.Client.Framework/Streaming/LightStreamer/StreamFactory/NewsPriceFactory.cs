using System;
using Common.Logging;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.StreamFactory
{
    public class NewsStreamFactory : INewsStreamFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(NewsStreamFactory));

        public virtual NewsStream Create(ILsCityindexStreamingConnection lsCityindexStreamingConnection)
        {
            try
            {
                Log.Info("Creating news stream listener.");
                
                var newsStream = new NewsStream(lsCityindexStreamingConnection);

                return newsStream;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
