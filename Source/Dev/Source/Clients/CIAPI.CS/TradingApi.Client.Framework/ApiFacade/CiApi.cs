using System;
using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Framework.Services;
using TradingApi.Client.Framework.Streaming;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;

namespace TradingApi.Client.Framework.ApiFacade
{
    public class CiApi
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CiApi));
        private static volatile CiApi _uniqueInstance;
        private static readonly object Lock = new object();
        private bool _loggedIn;
        private IApiConnection _apiConnection = new ApiConnection();
        private IStreamingManager _streamingManager;
        private ServiceManager _serviceManager;

        private CiApi(){}

        public static CiApi Instance
        {
            get
            {
                if (_uniqueInstance == null)
                {
                    lock (Lock)
                    {
                        if (_uniqueInstance == null)
                        {
                            _uniqueInstance = new CiApi();
                        }
                    }
                }
                return _uniqueInstance;
            }
        }

        internal IApiConnection ApiConnection
        {
            get { return _apiConnection; }
        }

        internal void SetUpApiForMocking(IApiConnection apiConnection, IStreamingManager streamingManager)
        {
            _apiConnection = apiConnection;
            _streamingManager = streamingManager;
        }
        
        public IStreamingManager StreamingManager
        {
            get
            {
                try
                {
                    if (!LoggedIn)
                        throw new NullReferenceException("Must be logged in.");
                    if (_streamingManager != null) return _streamingManager;
                    _streamingManager = new StreamingManager(new LightStreamerConnectionManager(_apiConnection));
                    return _streamingManager;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    throw;
                }
            }
        }

        public ServiceManager ServiceManager
        {
            get {
                try
                {
                    if (!LoggedIn)
                        throw new NullReferenceException("Must be logged in.");

                    if (_serviceManager != null) return _serviceManager;
                    return _serviceManager = new ServiceManager(_apiConnection);
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    throw;
                }
            }
        }

        public bool LoggedIn
        {
            get { return _loggedIn; }
        }

        public string UserName
        {
            get
            {
                try
                {
                    if (!LoggedIn)
                        throw new NullReferenceException("Must be logged in.");
                    return _apiConnection.UserName;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    throw;
                }
            }
        }

        public string Session
        {
            get
            {
                try
                {
                    if (!LoggedIn)
                        throw new NullReferenceException("Must be logged in.");
                    return _apiConnection.Session;
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    throw;
                }
            }
        }

        public virtual ApiLogOnResponseDTO Login(string username, string password, string tradingUrl)
        {
            try
            {
                if (_loggedIn)
                    throw new InvalidOperationException("Already logged in.");

                var response = _apiConnection.Login(username, password, tradingUrl);
                if (response.Session != null)
                    _loggedIn = true;
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
           
        }

        public virtual void Logout()
        {
            if (!LoggedIn) return;

            Log.Info("Logging out.");
            _apiConnection.Logout();
            _loggedIn = false;

            if(_streamingManager != null)
                _streamingManager.Disconnect();
        }
    }
}
