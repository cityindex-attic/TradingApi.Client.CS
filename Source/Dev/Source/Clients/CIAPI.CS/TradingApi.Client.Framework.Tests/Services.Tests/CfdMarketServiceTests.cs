using System.Collections.Generic;
using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;
using TradingApi.CoreDTO;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class CfdMarketServiceTests
    {
        [Test]
        public void ListCfdMarketsCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const string query = "query";
            const bool searchByMarketName = true;
            const bool searchByMarketCode = false;
            const int clientAccount = 34234;
            const int maxResults = 10;

            var mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
            var mockCfdMarketQuery = MockRepository.GenerateMock<CfdMarketQuery>(mockConnection);
            
            mockCfdMarketQuery.Expect(x => x.ListCfdMarkets(query, searchByMarketName, searchByMarketCode, clientAccount, maxResults))
                .Return(new ListCfdMarketsResponseDTO(new List<ApiMarketDTO>()));

            //Act
            var response = new CfdMarketService(mockCfdMarketQuery).ListCfdMarkets(query, searchByMarketName, searchByMarketCode, clientAccount, maxResults);

            //Assert
            Assert.IsInstanceOfType(typeof(ListCfdMarketsResponseDTO), response);
            mockCfdMarketQuery.VerifyAllExpectations();
        }
    }
}
