using System;
using System.Configuration;
using System.Threading;
using Common.Logging;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.Services
{
    public class NewsServiceSample
    {
        private static ILog Log = LogManager.GetLogger(typeof(NewsServiceSample));

        public static void Run()
        {
            Log.Info("NewsService sample...");

            // Get the username and password
            string username = ConfigurationManager.AppSettings["TradingAccountCode"];
            string password = ConfigurationManager.AppSettings["Password"];

            // Get trading api base uri
            string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

            // Login
            CiApi.Instance.Login(username, password, tradingApiBaseUri);

            // Get latest 20 news headline for uk
            var newsHeadlinesResponseDTO = CiApi.Instance.ServiceManager.NewsService.ListNewsHeadlines("UK", 20);

            foreach (var newsDTO in newsHeadlinesResponseDTO.Headlines)
            {
                Log.Info(newsDTO.PublishDate + " Storyid: " + newsDTO.StoryId + " - " + newsDTO.Headline);
            }

            Thread.Sleep(10000);

            // Logout
            CiApi.Instance.Logout();
        }
    }
}
