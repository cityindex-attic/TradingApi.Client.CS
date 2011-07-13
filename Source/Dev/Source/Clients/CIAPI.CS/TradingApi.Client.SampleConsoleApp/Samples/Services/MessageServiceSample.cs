using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Common.Logging;
using RESTWebServicesDTO.Response;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.Services
{
    public class MessageServiceSample
    {
        private static ILog Log = LogManager.GetLogger(typeof(MessageServiceSample));

        public static void Run()
        {
            Log.Info("MessageServiceSample Lookup sample...");

            const string orderStatusReasonLookup = "OrderStatusReason";
            const string orderApplicabilityLookup = "OrderApplicability";
            const string instructionStatusReasonLookup = "InstructionStatusReason";
            const int polishCultureId = 20;
            const int englishCultureId = 69;

            // Get the username and password
            string username = ConfigurationManager.AppSettings["TradingAccountCode"];
            string password = ConfigurationManager.AppSettings["Password"];

            // Get trading api base uri
            string tradingApiBaseUri = ConfigurationManager.AppSettings["TradingApiBaseUri"];

            // Login
            CiApi.Instance.Login(username, password, tradingApiBaseUri);

            // Do lookups
            ApiLookupResponseDTO instructionStatusReasonResponse =
                CiApi.Instance.ServiceManager.MessageService.GetMessageLookup(instructionStatusReasonLookup,
                                                                              polishCultureId);

            Console.WriteLine("Instruction status reason lookup response...");
            foreach (var apiLookupDTO in instructionStatusReasonResponse.ApiLookupDTOList)
            {
                Log.Info(apiLookupDTO.Id + ") " + apiLookupDTO.Description);
            }

            ApiLookupResponseDTO orderApplicabilityResponse =
                CiApi.Instance.ServiceManager.MessageService.GetMessageLookup(orderApplicabilityLookup,
                                                                              englishCultureId);

            Console.WriteLine("Order applicability lookup response...");
            foreach (var apiLookupDTO in orderApplicabilityResponse.ApiLookupDTOList)
            {
                Log.Info(apiLookupDTO.Id + ") " + apiLookupDTO.Description);
            }

            ApiLookupResponseDTO orderStatusReasonResponse =
                CiApi.Instance.ServiceManager.MessageService.GetMessageLookup(orderStatusReasonLookup,
                                                                              englishCultureId);

            Console.WriteLine("Order status reason lookup response...");
            foreach (var apiLookupDTO in orderStatusReasonResponse.ApiLookupDTOList)
            {
                Log.Info(apiLookupDTO.Id + ") " + apiLookupDTO.Description);
            }
            
            Thread.Sleep(10000);

            // Logout
            CiApi.Instance.Logout();
        }
    }
}
