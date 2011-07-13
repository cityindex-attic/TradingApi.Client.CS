using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class SpreadMarketService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SpreadMarketService));
        private readonly SpreadMarketsQuery _spreadMarketsQuery;

        public SpreadMarketService(SpreadMarketsQuery spreadMarketsQuery)
        {
            _spreadMarketsQuery = spreadMarketsQuery;
        }

        public ListSpreadMarketsResponseDTO ListSpreadMarkets(string query, bool searchByMarketName, bool searchByMarketCode, int clientAccount, int maxResults)
        {
            Log.DebugFormat("Listing spread markets: query - '{0}', searchByMarketName - '{1}', searchByMarketCode - '{2}', clientAccount - '{3}', maxResults - '{4}'", query, searchByMarketName, searchByMarketCode, clientAccount, maxResults);
            return _spreadMarketsQuery.ListSpreadMarkets(query, searchByMarketName, searchByMarketCode, clientAccount, maxResults);
        }
    }
}