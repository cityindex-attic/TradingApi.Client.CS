using Common.Logging;
using RESTWebServicesDTO.Request;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Core;

namespace TradingApi.Client.Framework.Services
{
    public class FutureOptionService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(FutureOptionService));
        private readonly FutureOptionPlacer _futureOptionPlacer;

        public FutureOptionService(FutureOptionPlacer futureOptionPlacer)
        {
            _futureOptionPlacer = futureOptionPlacer;
        }

        public NewFutureOptionResponseDTO NewFutureOption(NewFutureOptionRequestDTO futureOptionRequestDTO)
        {
            Log.Debug("New future option request.");
            return _futureOptionPlacer.NewFutureOption(futureOptionRequestDTO);
        }
    }
}