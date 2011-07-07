using System;
using NUnit.Framework;
using RESTWebServicesDTO.Response;
using Rhino.Mocks;
using TradingApi.Client.Framework.ApiFacade;
using TradingApi.Client.Framework.Services;
using TradingApi.Client.Framework.Streaming;

namespace TradingApi.Client.Framework.Tests.ApiFacade.Tests
{
    [TestFixture]
    public class CiApiTests
    {
        private const string USERNAME = "userName";
        private const string PASSWORD = "password";
        private const string TRADING_URL = "http://couldBeAnyUrl/TradingApi";
        private IApiConnection _mockApiConnection;
        private IStreamingManager _mockStreamingManager;
        private MarketInfoServiceFactory _mockMarketInfoServiceFactory;
        private AccountInfoServiceFactory _mockAccountInfoServiceFactory;
        private CfdMarketServiceFactory _mockCfdMarketServiceFactory;
        private OrderServiceFactory _mockOrderServiceFactory;

        [SetUp]
        public void Setup()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
            _mockStreamingManager = MockRepository.GenerateMock<IStreamingManager>();
            _mockMarketInfoServiceFactory = MockRepository.GenerateMock<MarketInfoServiceFactory>();
            _mockAccountInfoServiceFactory = MockRepository.GenerateMock<AccountInfoServiceFactory>();
            _mockCfdMarketServiceFactory = MockRepository.GenerateMock<CfdMarketServiceFactory>();
            _mockOrderServiceFactory = MockRepository.GenerateMock<OrderServiceFactory>();
        }

        [Test]
        public void NewInstanceInstantiatesAnApiConnection()
        {
            Assert.IsNotNull(CiApi.Instance.ApiConnection);
        }
        
        [Test]
        public void LoginCallsApiConnectionLoginMethodAndIfItsSessionIsNotNullLoggedInIsSetToTrue()
        {
            // Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            var response = new ApiLogOnResponseDTO(){Session = "validSession"};
            _mockApiConnection.Expect(x => x.Login(USERNAME, PASSWORD, TRADING_URL)).Return(response);
            
            // Act
            var result = CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);

            // Assert
            Assert.IsTrue(CiApi.Instance.LoggedIn);
            Assert.AreEqual(response, result);
            _mockApiConnection.VerifyAllExpectations();
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void InvalidOperationExceptionThrownIfTryToLogInWhenAlreadyLoggedIn()
        {
            // Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            var response = new ApiLogOnResponseDTO(){Session = "newSession"};
            _mockApiConnection.Expect(x => x.Login(USERNAME, PASSWORD, TRADING_URL)).Return(response);

            // Act
            CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);
            // log in again
            CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);
            _mockApiConnection.VerifyAllExpectations();
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void NullExceptionThrownIfTryToGetUsernameBeforeLoggedOn()
        {
            //Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            //Act
            string usernameBeforeLoggedOn = CiApi.Instance.UserName;
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void NullExceptionThrownIfTryToGetSessionBeforeLoggedOn()
        {
            //Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            //Act
            string sessionBeforeLoggedOn = CiApi.Instance.Session;
        }

        [Test]
        public void IfLoggedInThenLogoutCallsDisconnectsTheStreamingManager()
        {
            // Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            // Login
            var apiLogOnResponseDTO = new ApiLogOnResponseDTO() { Session = "session" };
            _mockApiConnection.Expect(x => x.Login(USERNAME, PASSWORD, TRADING_URL)).Return(apiLogOnResponseDTO);

            _mockStreamingManager.Expect(x => x.Disconnect());

            // Act
            CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);
            CiApi.Instance.Logout();

            // Assert
            _mockStreamingManager.VerifyAllExpectations();
        }

        [Test]
        public void LogoutCallsTheApiConnectionLogoutMethod()
        {
            // Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            var apiLogOnResponseDTO = new ApiLogOnResponseDTO() { Session = "session" };
            _mockApiConnection.Expect(x => x.Login(USERNAME, PASSWORD, TRADING_URL)).Return(apiLogOnResponseDTO);
            _mockApiConnection.Expect(x => x.Logout());

            // Act
            CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);
            CiApi.Instance.Logout();

            // Assert
            _mockApiConnection.VerifyAllExpectations();
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void NullExceptionThrownIfTryToLoadStreamingManagerBeforeLoggedOn()
        {
            //Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            //Act
            var shouldNotGetHere = CiApi.Instance.StreamingManager;
        }

        [Test]
        public void StreamingManagerPropertyLoadsTheFirstTimeItsCalled()
        {
            //Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            // Log in
            var apiLogOnResponseDTO = new ApiLogOnResponseDTO(){Session = "session"};
            _mockApiConnection.Expect(x => x.Login(USERNAME, PASSWORD, TRADING_URL)).Return(apiLogOnResponseDTO);
            
            // Act
            CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);
            var streamingManager = CiApi.Instance.StreamingManager;
            var streamingManagerSecondCall = CiApi.Instance.StreamingManager;

            // Assert
            Assert.IsNotNull(streamingManager);
            Assert.AreEqual(streamingManager, streamingManagerSecondCall);
            _mockApiConnection.VerifyAllExpectations();
        }

        [Test]
        public void IfNotLoggedInLogoutDoesNotCallTheApiConnectionLogoutMethod()
        {
            // Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            // Login
            var response = new ApiLogOnResponseDTO(){Session = "session"};
            _mockApiConnection.Expect(x => x.Login(USERNAME, PASSWORD, TRADING_URL)).Return(response).Repeat.Once();
            CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);

            _mockApiConnection.Expect(x => x.Logout());
            
            // Act
            CiApi.Instance.Logout();

            // Assert
            _mockApiConnection.VerifyAllExpectations();
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void NullExceptionThrownIfTryToLoadServiceManagerBeforeLoggedOn()
        {
            //Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            //Act
            var shouldNotGetHere = CiApi.Instance.ServiceManager;
        }

        [Test]
        public void ServiceManagerPropertyLoadsTheFirstTimeItsCalled()
        {
            //Arrange
            CiApi.Instance.SetUpApiForMocking(_mockApiConnection, _mockStreamingManager);
            SetUpApiInstanceToBeLoggedOut();

            // Log in
            var apiLogOnResponseDTO = new ApiLogOnResponseDTO() { Session = "session" };
            _mockApiConnection.Expect(x => x.Login(USERNAME, PASSWORD, TRADING_URL)).Return(apiLogOnResponseDTO);

            // Act
            CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);
            var serviceManager = CiApi.Instance.ServiceManager;
            var serviceManagerSecondCall = CiApi.Instance.ServiceManager;

            // Assert
            Assert.IsNotNull(serviceManager);
            Assert.AreEqual(serviceManager, serviceManagerSecondCall);
            _mockApiConnection.VerifyAllExpectations();
        }

        private void SetUpApiInstanceToBeLoggedOut()
        {
            if(!CiApi.Instance.LoggedIn)
            {
                var response = new ApiLogOnResponseDTO();
                _mockApiConnection.Expect(x => x.Login(USERNAME, PASSWORD, TRADING_URL)).Return(response).Repeat.Once();
                CiApi.Instance.Login(USERNAME, PASSWORD, TRADING_URL);
            }
            CiApi.Instance.Logout();
        }
    }
}
