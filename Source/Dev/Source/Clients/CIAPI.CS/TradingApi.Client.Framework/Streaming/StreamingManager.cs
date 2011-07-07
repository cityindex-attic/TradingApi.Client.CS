using System;
using Common.Logging;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;

namespace TradingApi.Client.Framework.Streaming
{
    public class StreamingManager : IStreamingManager
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(StreamingManager));
        private readonly LightStreamerConnectionManager _lightStreamerConnectionManager;
        private Streams _streams;

        internal StreamingManager(LightStreamerConnectionManager lightStreamerConnectionManager)
        {
            _lightStreamerConnectionManager = lightStreamerConnectionManager;
        }

        public LightStreamerConnectionManager LightStreamerConnectionManager
        {
            get
            {
                return _lightStreamerConnectionManager;
            }
        }
        
        public Streams Streams
        {
            get
            {
                if(string.IsNullOrEmpty(StreamingUrl))
                    throw new NullReferenceException("Must set the streamingUrl property first.");

                if (_streams != null) return _streams;
                _streams = new Streams(this);
                return _streams;
            }
        }

        public string StreamingUrl { get; set; }

        public virtual void Disconnect()
        {
            try
            {
                _lightStreamerConnectionManager.Disconnect();
                Log.Debug("Streaming clients disconnected.");
                
            }
            catch (Exception ex)
            {
                Log.Error("Error trying to disconnect streaming client: " + ex);
                throw;
            }
        }
    }
}
