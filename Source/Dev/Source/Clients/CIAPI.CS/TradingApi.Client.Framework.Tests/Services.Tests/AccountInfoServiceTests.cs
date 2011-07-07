using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class AccountInfoServiceTests
    {
        [Test]
        public void GetClientAndTradingAccountCallsTheCorrectMethodFromTheUnderlyingMarketInformationQueryClass()
        {
            //Arrange
            var mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
            var mockAccountInformationQuery = MockRepository.GenerateMock<AccountInformationQuery>(mockConnection);
            
            mockAccountInformationQuery.Expect(x => x.GetClientAndTradingAccount())
                .Return(new AccountInformationResponseDTO());

            //Act
            var response = new AccountInfoService(mockAccountInformationQuery).GetClientAndTradingAccount();

            //Assert
            Assert.IsInstanceOfType(typeof(AccountInformationResponseDTO), response);
            mockAccountInformationQuery.VerifyAllExpectations();
        }
    }
}
