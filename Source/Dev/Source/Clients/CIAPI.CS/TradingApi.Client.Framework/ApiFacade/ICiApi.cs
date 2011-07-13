using RESTWebServicesDTO.Response;
using TradingApi.Client.Framework.Services;
using TradingApi.Client.Framework.Streaming;

namespace TradingApi.Client.Framework.ApiFacade
{
    public interface ICiApi
    {
        IStreamingManager StreamingManager { get; }
        ServiceManager ServiceManager { get; }
        bool LoggedIn { get; }
        string UserName { get; }
        string Session { get; }
        ApiLogOnResponseDTO Login(string username, string password, string tradingUrl);
        void Logout();
    }
}