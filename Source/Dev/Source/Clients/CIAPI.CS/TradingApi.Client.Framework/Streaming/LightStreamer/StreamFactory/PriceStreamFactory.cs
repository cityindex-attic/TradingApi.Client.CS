using System;
using Common.Logging;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.StreamFactory
{
    internal class PriceStreamFactory : IPriceStreamFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(PriceStreamFactory));

        public virtual PriceStream Create(ILsCityindexStreamingConnection lsCityindexStreamingConnection)
        {
            try
            {
                Log.Info("Creating price stream listener.");
                
                var priceStream = new PriceStream(lsCityindexStreamingConnection);

                return priceStream;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
