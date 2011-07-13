using System.Collections.Generic;
using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class MarketInformationService : ServiceBase
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MarketInformationService));
        private readonly MarketInformationQuery _marketInformationQuery;

        internal MarketInformationService(
            MarketInformationQuery marketInformationQuery)
        {
            _marketInformationQuery = marketInformationQuery;
        }

        public GetMarketInformationResponseDTO GetMarketInformation(int marketId)
        {
            Log.InfoFormat("Getting market information with market id: {0}.", marketId);
            var marketInfo = _marketInformationQuery.GetMarketInformation(marketId);
            return marketInfo;
        }

        public ListMarketInformationResponseDTO ListMarketInformation(List<int> marketIdList)
        {
            Log.InfoFormat("Getting market information list with market ids: {0}", marketIdList);
            return _marketInformationQuery.ListMarketInformation(marketIdList);
        }
    }
}