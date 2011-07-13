using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.MockingTheApi
{
    public class ClientLoginClass
    {
        private ICiApi _ciApi;

        public ClientLoginClass(ICiApi ciApi)
        {
            _ciApi = ciApi;
        }

        public ClientLoginClass() : this(CiApi.Instance)
        {
        }

        public string ClientLogin(string username, string password, string tradingUrl)
        {
            return _ciApi.Login(username, password, tradingUrl).Session;
        }
    }
}