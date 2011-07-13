using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class MessageService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MessageService));
        private readonly MessageLookupQuery _messageLookupQuery;

        public MessageService(MessageLookupQuery messageLookupQuery)
        {
            _messageLookupQuery = messageLookupQuery;
        }

        public ApiLookupResponseDTO GetMessageLookup(string lookupEntityName, int cultureId)
        {
            Log.DebugFormat("Getting message lookup for entity '{0}' with culture id '{1}'", lookupEntityName, cultureId);
            return _messageLookupQuery.GetMessageLookup(lookupEntityName, cultureId);
        }
    }
}