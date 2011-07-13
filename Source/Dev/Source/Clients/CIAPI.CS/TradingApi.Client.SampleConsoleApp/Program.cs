using TradingApi.Client.Framework;
using Common.Logging;
using TradingApi.Client.SampleConsoleApp.Samples.MockingTheApi;
using TradingApi.Client.SampleConsoleApp.Samples.Services;
using TradingApi.Client.SampleConsoleApp.Samples.Streams;

namespace TradingApi.Client.SampleConsoleApp
{
    class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof(Program)); 

        static void Main(string[] args)
        {
            //LoginSample.Run();
            //SubscribeToPriceStreamSample.Run();
            //SubscribeToPriceListStreamSample.Run();
            //AccountInformationServiceSample.Run();
            //CfdMarketServiceSample.Run();
            //MarketInformationServiceSample.Run();
            //SubscribeToNewsStreamSample.Run();
            //SubscribeToOrderStreamSample.Run();
            //SubscribeToMultipleStreams.Run();
            //OrderServiceSample.Run();
            //MockableLoginSample.Run();
            //MessageServiceSample.Run();
            //NewsServiceSample.Run();
            SpreadMarketServiceSample.Run();

            Log.Info("Sample completed!");
        }
    }
}
