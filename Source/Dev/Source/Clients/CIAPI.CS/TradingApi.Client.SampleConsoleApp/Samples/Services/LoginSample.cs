using System;
using System.Configuration;
using System.Threading;
using Common.Logging;
using TradingApi.Client.Core.Exceptions;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.Services
{
    public class LoginSample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginSample)); 

        public static void Run()
        {
            try
            {
                Log.Info("Login sample...");

                // Get the username and password
                string username = ConfigurationManager.AppSettings["TradingAccountCode"];
                string password = ConfigurationManager.AppSettings["Password"];

                // Get trading api base uri
                string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

                // Login
                string session = CiApi.Instance.Login(username, password, tradingApiBaseUri).Session;
                
                // Client session
                Log.Info("My session: " + session);

                Thread.Sleep(10000);
            }
            catch (ApiCallException apiCallException)
            {
                Log.Error(apiCallException.Message);
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                Thread.Sleep(10000);
            }
        }
    }
}
