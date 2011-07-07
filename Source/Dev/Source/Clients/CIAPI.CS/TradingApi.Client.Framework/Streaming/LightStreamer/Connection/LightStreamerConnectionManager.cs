using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using StreamingClient;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory;

namespace TradingApi.Client.Framework.Streaming.LightStreamer.Connection
{
    public class LightStreamerConnectionManager
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LightStreamerConnectionManager));
        private const string CITYINDEX_STREAMING_ADAPTER = "/CITYINDEXSTREAMING";
        private const string STREAMING_CLIENT_ACCOUNT_ADAPTER = "/STREAMINGCLIENTACCOUNT";
        private ILsCityindexStreamingConnection _lsCityindexStreamingConnection;
        private ILsStreamingClientAccountConnection _lsStreamingClientAccountConnection;
        private readonly IApiConnection _apiConnection;
        private bool _cityindexStreamingAdapterIsConnected;
        private bool _streamingClientAccountAdapterIsConnected;

        public LightStreamerConnectionManager(){}

        public LightStreamerConnectionManager(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection; 
        }

        public virtual ILsCityindexStreamingConnection LsCityindexStreamingConnection
        {
            get { return _lsCityindexStreamingConnection; }
        }

        public virtual ILsStreamingClientAccountConnection LsStreamingClientAccountConnection
        {
            get { return _lsStreamingClientAccountConnection; }
        }

        public virtual bool CityindexStreamingAdaterIsConnected
        {
            get { return _cityindexStreamingAdapterIsConnected; }
        }

        public virtual bool StreamingClientAccountAdapterIsConnected 
        {
            get { return _streamingClientAccountAdapterIsConnected; }
        }

        public virtual void ConnectToCityindexStreamingAdapter(string streamingUrl, LsCityindexStreamingConnectionFactory lsCityindexStreamingConnectionFactory)
        {
            if(_cityindexStreamingAdapterIsConnected)
                throw new InvalidOperationException("Can only have one connection open to a lightstreamer cityindex streaming adapter.");

            var cityIndexStreamingAdapterUri = streamingUrl + CITYINDEX_STREAMING_ADAPTER;
            Log.Info("Connecting to lightstreamer uri: " + cityIndexStreamingAdapterUri);
            _lsCityindexStreamingConnection = lsCityindexStreamingConnectionFactory.Create(new Uri(cityIndexStreamingAdapterUri), _apiConnection.UserName, _apiConnection.Session);
            if (_lsCityindexStreamingConnection == null)
                throw new NullReferenceException("Could not create CityindexStreaming adapter connection.");

            _lsCityindexStreamingConnection.StatusChanged += new EventHandler<StatusEventArgs>(LsCityindexStreamingClientConnectionStatusChanged);
            _lsCityindexStreamingConnection.Connect();
            _cityindexStreamingAdapterIsConnected = true;
        }

        public virtual void ConnectToStreamingClientAccountAdapter(string streamingUrl, LsStreamingClientAccountConnectionFactory lsStreamingClientAccountConnectionFactory)
        {
            if (_streamingClientAccountAdapterIsConnected)
                throw new InvalidOperationException("Can only have one connection open to a lightstreamer streaming client account adapter.");

            var streamingClientAccountAdapterUri = streamingUrl + STREAMING_CLIENT_ACCOUNT_ADAPTER;
            Log.Info("Connecting to lightstreamer uri: " + streamingClientAccountAdapterUri);
            _lsStreamingClientAccountConnection = lsStreamingClientAccountConnectionFactory.Create(new Uri(streamingClientAccountAdapterUri), _apiConnection.UserName, _apiConnection.Session);
            if (_lsStreamingClientAccountConnection == null)
                throw new NullReferenceException("Could not create StreamingClientAccount adapter connection.");

            _lsStreamingClientAccountConnection.StatusChanged += new EventHandler<StatusEventArgs>(LsStreamingClientAccountConnectionStatusChanged);
            _lsStreamingClientAccountConnection.Connect();
            _streamingClientAccountAdapterIsConnected = true;
        }

        //todo:test these events are being invoked
        private static void LsStreamingClientAccountConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            if (e.Status.Contains("Connection established"))
                Log.Info("Lightstreamer StreamingClientAccount adapter connected");
        }

        private static void LsCityindexStreamingClientConnectionStatusChanged(object sender, StatusEventArgs e)
        {
            if (e.Status.Contains("Connection established"))
                Log.Info("Lightstreamer CityindexStreamingClient adapter connected");
        }

        public virtual void Disconnect()
        {
            if (_lsCityindexStreamingConnection != null)
            {
                _lsCityindexStreamingConnection.Disconnect();
                _cityindexStreamingAdapterIsConnected = false;
            }
                
            if (_lsStreamingClientAccountConnection != null)
            {
                _lsStreamingClientAccountConnection.Disconnect();
                _streamingClientAccountAdapterIsConnected = false;
            }
        }
    }
}
