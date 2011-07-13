using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    [TestFixture]
    public class NewsServiceTests
    {
        private Connection _mockConnection;

        [SetUp]
        public void SetUp()
        {
            _mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
        }

        [Test]
        public void ListNewsHeadlinesCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const string category = "UK";
            const int maxResults = 20;
            var mockNewsQuery = MockRepository.GenerateMock<NewsQuery>(_mockConnection);
            mockNewsQuery.Expect(x => x.ListNewsHeadlines(category, maxResults))
                .Return(new ListNewsHeadlinesResponseDTO());

            //Act
            var response = new NewsService(mockNewsQuery).ListNewsHeadlines(category, maxResults);

            //Assert
            Assert.IsInstanceOfType(typeof(ListNewsHeadlinesResponseDTO), response);
            mockNewsQuery.VerifyAllExpectations();
        }

        [Test]
        public void GetNewsDetailCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const int storyId = 1;
            var mockNewsQuery = MockRepository.GenerateMock<NewsQuery>(_mockConnection);
            mockNewsQuery.Expect(x => x.GetNewsDetail(storyId))
                .Return(new GetNewsDetailResponseDTO());

            //Act
            var response = new NewsService(mockNewsQuery).GetNewsDetail(storyId);

            //Assert
            Assert.IsInstanceOfType(typeof(GetNewsDetailResponseDTO), response);
            mockNewsQuery.VerifyAllExpectations();
        }
    }
}
