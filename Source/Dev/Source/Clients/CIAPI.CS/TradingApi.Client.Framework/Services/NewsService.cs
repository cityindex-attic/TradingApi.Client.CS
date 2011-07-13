using System;
using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class NewsService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(NewsService));
        private readonly NewsQuery _newsQuery;

        public NewsService(NewsQuery newsQuery)
        {
            _newsQuery = newsQuery;
        }

        public ListNewsHeadlinesResponseDTO ListNewsHeadlines(string category, int maxResults)
        {
            Log.DebugFormat("List '{0}' headlines for news category '{1}'.", maxResults, category);
            return _newsQuery.ListNewsHeadlines(category, maxResults);
        }

        public GetNewsDetailResponseDTO GetNewsDetail(int storyId)
        {
            Log.DebugFormat("Getting news detail for story id '{0}'.", storyId);
            return _newsQuery.GetNewsDetail(storyId);
        }
    }
}