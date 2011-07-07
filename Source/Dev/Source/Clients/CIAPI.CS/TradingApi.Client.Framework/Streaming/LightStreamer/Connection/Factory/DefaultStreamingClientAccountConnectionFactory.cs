using System;
using Common.Logging;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory
{
    public class DefaultStreamingClientAccountConnectionFactory : LsStreamingClientAccountConnectionFactory
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DefaultStreamingClientAccountConnectionFactory));

        public override ILsStreamingClientAccountConnection Create(Uri streamingAndAdapterUri, string username, string session)
        {
            try
            {
                return new LsGenericStreamingClientAccountConnection(streamingAndAdapterUri, username, session);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
