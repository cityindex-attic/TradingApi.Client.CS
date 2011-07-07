using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework
{
    public interface IApiConnection
    {
        string UserName { get; }
        string Session { get; }
        bool LoggedIn { get; }
        Connection CoreConnection { get; }
        ApiLogOnResponseDTO Login(string username, string password, string tradingUrl);
        void Logout();
    }
}