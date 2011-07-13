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
    public class MessageServiceTests
    {
        private Connection _mockConnection;

        [SetUp]
        public void SetUp()
        {
            _mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
        }

        [Test]
        public void GetMessageLookupCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            const string lookupEntityName = "OrderApplicability";
            const int cultureId = 69;
            var mockMessageLookupQuery = MockRepository.GenerateMock<MessageLookupQuery>(_mockConnection);
            mockMessageLookupQuery.Expect(x => x.GetMessageLookup(lookupEntityName, cultureId))
                .Return(new ApiLookupResponseDTO());

            //Act
            var response = new MessageService(mockMessageLookupQuery).GetMessageLookup(lookupEntityName, cultureId);

            //Assert
            Assert.IsInstanceOfType(typeof(ApiLookupResponseDTO), response);
            mockMessageLookupQuery.VerifyAllExpectations();
        }
    }
}
