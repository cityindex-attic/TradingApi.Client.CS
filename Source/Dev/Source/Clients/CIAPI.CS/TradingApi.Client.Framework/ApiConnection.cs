using System;
using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework
{
    public class ApiConnection : IApiConnection
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ApiConnection));
        private static Connection _coreConnection;
        private ApiLogOnResponseDTO _apiLogOnResponseDTO;
        private static string _userName;
        private static string _session;
        private bool _loggedIn;

        internal ApiConnection(){}

        internal ApiConnection(Connection connection)
        {
            _coreConnection = connection;
        }

        public string UserName
        {
            get { return _userName; }
        }

        public string Session
        {
            get { return _session; }
        }

        public Connection CoreConnection
        {
            get { return _coreConnection; }
        }

        public bool LoggedIn
        {
            get { return _loggedIn; }
        }

        public virtual ApiLogOnResponseDTO Login(string username, string password, string tradingUrl)
        {
            try
            {
                if (_loggedIn)
                {
                    Log.Info("Tried to log in twice, must log off before logging in again.");
                    return _apiLogOnResponseDTO;
                }

                Log.Debug("logging in with username " + username + ".");
                if (_coreConnection == null)
                    _coreConnection = new Connection(username, password, tradingUrl);
                
                _apiLogOnResponseDTO = _coreConnection.Authenticate(username, password);

                _userName = username;
                _session = _apiLogOnResponseDTO.Session;
                _loggedIn = true;
                return _apiLogOnResponseDTO;
            }
            catch (Exception ex)
            {
                Log.Error("Error trying to log in: " + ex);
                throw;
            }
        }

        public virtual void Logout()
        {
            Log.Debug("Setting Trading api core connection to null.");
            _coreConnection = null;
            _loggedIn = false;
        }
    }
}