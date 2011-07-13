using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using RESTWebServicesDTO.Request;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Services;

namespace TradingApi.Client.Framework.Tests.Services.Tests
{
    public class FutureOptionServiceTests
    {
        private Connection _mockConnection;

        [SetUp]
        public void SetUp()
        {
            _mockConnection = MockRepository.GenerateMock<Connection>("username", "password", "http://couldBeAnyUrl/TradingApi");
        }

        [Test]
        public void NewFutureOptionCallsTheCorrectMethodFromTheUnderlyingCore()
        {
            //Arrange
            var futureOptionRequestDTO = new NewFutureOptionRequestDTO();
            var mockFutureOptionPlacer = MockRepository.GenerateMock<FutureOptionPlacer>(_mockConnection);
            mockFutureOptionPlacer.Expect(x => x.NewFutureOption(futureOptionRequestDTO))
                .Return(new NewFutureOptionResponseDTO());

            //Act
            var response = new FutureOptionService(mockFutureOptionPlacer).NewFutureOption(futureOptionRequestDTO);

            //Assert
            Assert.IsInstanceOfType(typeof(NewFutureOptionResponseDTO), response);
            mockFutureOptionPlacer.VerifyAllExpectations();
        }
    }
}
