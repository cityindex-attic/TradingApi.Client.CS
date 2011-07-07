using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class CfdMarketService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CfdMarketService));
        private readonly CfdMarketQuery _cfdMarketQuery;

        internal CfdMarketService(CfdMarketQuery cfdMarketQuery)
        {
            _cfdMarketQuery = cfdMarketQuery;
        }
        
        public ListCfdMarketsResponseDTO ListCfdMarkets(string query, bool searchByMarketName, bool searchByMarketCode, int clientAccount, int maxResults)
        {
            Log.InfoFormat("List CFD markets: query - {0}, searchByMarketName - {1}, searchByMarketCode - {2}, clientAccount - {3}, marketResults - {4}", query, searchByMarketName, searchByMarketCode, clientAccount, maxResults);
            return _cfdMarketQuery.ListCfdMarkets(query, searchByMarketName, searchByMarketCode, clientAccount, maxResults);
        }
    }
}