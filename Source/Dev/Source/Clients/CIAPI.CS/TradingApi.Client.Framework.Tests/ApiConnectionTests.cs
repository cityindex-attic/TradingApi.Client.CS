using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Core;
using TradingApi.Client.Framework.Streaming;

namespace TradingApi.Client.Framework.Tests
{
    [TestFixture]
    public class ApiConnectionTests
    {
        private const string USERNAME = "userName";
        private const string PASSWORD = "password";
        private const string TRADING_URL = "http://couldBeAnyUrl/TradingApi";
        private const string SESSION_ID = "sessionString";
        private Connection _mockConnection;
        private ApiConnection _apiConnection;

        [SetUp]
        public void Setup()
        {
            _mockConnection = MockRepository.GenerateMock<Connection>(USERNAME, PASSWORD, TRADING_URL);
            _apiConnection = new ApiConnection(_mockConnection);
        }

        [Test]
        public void LogoutClearsTheTradingApiCoreConnection()
        {
            // Assert 
            Assert.IsNotNull(_apiConnection.CoreConnection);

            // Act
            _apiConnection.Logout();
            
            // Assert
            Assert.IsNull(_apiConnection.CoreConnection);
        }

        [Test]
        public void LoginCreatesATradingConnectionAndReturnsASessionAndSetsLoggedInToTrue()
        {
            // Arrange
            var logOnResponseDTO = new ApiLogOnResponseDTO {Session = SESSION_ID};

            _mockConnection.Expect(x => x.Authenticate(USERNAME, PASSWORD))
                .Return(logOnResponseDTO);

            // Act
            var apiLogOnResponseDTO = _apiConnection.Login(USERNAME, PASSWORD, TRADING_URL);

            // Assert
            Assert.AreEqual(SESSION_ID, apiLogOnResponseDTO.Session);
            Assert.IsTrue(_apiConnection.LoggedIn);
            _mockConnection.VerifyAllExpectations();
        }

        [Test]
        public void IfLoginIsCalledTwiceOnlyOneConnectionIsCreated()
        {
            // Arrange
            var logOnResponseDTO = new ApiLogOnResponseDTO { Session = SESSION_ID };

            _mockConnection.Expect(x => x.Authenticate(USERNAME, PASSWORD))
                .Return(logOnResponseDTO)
                .Repeat.Once();

            // Act
            var apiLogOnResponseDTO = _apiConnection.Login(USERNAME, PASSWORD, TRADING_URL);
            var apiLogOnResponseDTOSecondCall = _apiConnection.Login(USERNAME, PASSWORD, TRADING_URL);

            // Assert
            Assert.AreEqual(apiLogOnResponseDTO, apiLogOnResponseDTOSecondCall);
            _mockConnection.VerifyAllExpectations();
        }

        [Test]
        public void LogoutSetsCoreConnectionToNullAndLoggedInStatusToFalse()
        {
            // Arrange
            var logOnResponseDTO = new ApiLogOnResponseDTO { Session = SESSION_ID };

            _mockConnection.Expect(x => x.Authenticate(USERNAME, PASSWORD))
                .Return(logOnResponseDTO)
                .Repeat.Once();

            // Assert before logout
            _apiConnection.Login(USERNAME, PASSWORD, TRADING_URL);
            Assert.IsNotNull(_apiConnection.CoreConnection);
            Assert.IsTrue(_apiConnection.LoggedIn);

            // Act
            _apiConnection.Logout();
            
            // Assert
            Assert.IsNull(_apiConnection.CoreConnection);
            Assert.IsFalse(_apiConnection.LoggedIn);
            _mockConnection.VerifyAllExpectations();
        }
    
    }
}
