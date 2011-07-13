using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;
using TradingApi.CoreDTO;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class SpreadMarketsServiceTests
    {
        private Connection _mockConnection;

        [SetUp]
        public void SetUp()
        {
            _mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
        }

        [Test]
        public void ListSpreadMarketsCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const string query = "query";
            const bool searchByMarketName = true;
            const bool searchByMarketCode = false;
            const int clientAccount = 34234;
            const int maxResults = 10;

            var mockSpreadMarketsQuery = MockRepository.GenerateMock<SpreadMarketsQuery>(_mockConnection);
            mockSpreadMarketsQuery.Expect(x => x.ListSpreadMarkets(query, searchByMarketName, searchByMarketCode, clientAccount, maxResults))
                .Return(new ListSpreadMarketsResponseDTO(new List<ApiMarketDTO>()));

            //Act
            var response = new SpreadMarketService(mockSpreadMarketsQuery).ListSpreadMarkets(query, searchByMarketName, searchByMarketCode, clientAccount, maxResults);

            //Assert
            Assert.IsInstanceOfType(typeof(ListSpreadMarketsResponseDTO), response);
            mockSpreadMarketsQuery.VerifyAllExpectations();
        }
    }
}
