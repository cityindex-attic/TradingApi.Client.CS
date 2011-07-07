using System.Collections.Generic;
using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class MarketInfoServiceTests
    {
        private Connection _mockConnection;

        [SetUp]
        public void SetUp()
        {
            _mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
        }

        [Test]
        public void GetMarketInfoCallsTheCorrectMethodFromTheUnderlyingMarketInformationQueryClass()
        {
            //Arrange
            const int marketId = 5;
            var mockMarketInformationQuery = MockRepository.GenerateMock<MarketInformationQuery>(_mockConnection);
            mockMarketInformationQuery.Expect(x => x.GetMarketInformation(marketId))
                .Return(new GetMarketInformationResponseDTO());

            //Act
            var response = new MarketInfoService(mockMarketInformationQuery).GetMarketInfo(marketId);

            //Assert
            Assert.IsInstanceOfType(typeof(GetMarketInformationResponseDTO), response);
            mockMarketInformationQuery.VerifyAllExpectations();
        }

        [Test]
        public void ListMarketInformationCallsTheCorrectMethodFromTheUnderlyingMarketInformationQueryClass()
        {
            //Arrange
            var marketIdList = new List<int>(){1,2,3};
            var mockMarketInformationQuery = MockRepository.GenerateMock<MarketInformationQuery>(_mockConnection);
            mockMarketInformationQuery.Expect(x => x.ListMarketInformation(marketIdList))
                .Return(new ListMarketInformationResponseDTO());

            //Act
            var response = new MarketInfoService(mockMarketInformationQuery).ListMarketInformation(marketIdList);

            //Assert
            Assert.IsInstanceOfType(typeof(ListMarketInformationResponseDTO), response);
            mockMarketInformationQuery.VerifyAllExpectations();
        }
    }
}
