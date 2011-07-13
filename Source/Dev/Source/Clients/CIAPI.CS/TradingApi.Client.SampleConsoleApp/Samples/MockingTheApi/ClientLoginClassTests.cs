using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Framework.ApiFacade;

namespace TradingApi.Client.SampleConsoleApp.Samples.MockingTheApi
{
    [TestFixture]
    public class ClientLoginClassTests
    {
        [Test]
        public void MockCiApi()
        {
            //Arrange
            ICiApi mockCiApi = MockRepository.GenerateMock<ICiApi>();
            string username = "user";
            string password = "pass";
            string tradingUrl = "trade";

            mockCiApi.Expect(x => x.Login(username, password, tradingUrl))
                .Return(new ApiLogOnResponseDTO() { Session = "sesh" });

            var aClientClass = new ClientLoginClass(mockCiApi);
            aClientClass.ClientLogin(username, password, tradingUrl);

            mockCiApi.VerifyAllExpectations();
        }
    }
}
