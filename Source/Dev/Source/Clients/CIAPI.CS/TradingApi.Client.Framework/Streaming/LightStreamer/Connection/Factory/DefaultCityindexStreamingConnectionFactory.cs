using System;
using Common.Logging;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory
{
    public class DefaultCityindexStreamingConnectionFactory : LsCityindexStreamingConnectionFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DefaultCityindexStreamingConnectionFactory));

        public override ILsCityindexStreamingConnection Create(Uri streamingAndAdapterUri, string username, string session)
        {
            try
            {
                return new LsGenericCityindexStreamingConnection(streamingAndAdapterUri, username, session);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
