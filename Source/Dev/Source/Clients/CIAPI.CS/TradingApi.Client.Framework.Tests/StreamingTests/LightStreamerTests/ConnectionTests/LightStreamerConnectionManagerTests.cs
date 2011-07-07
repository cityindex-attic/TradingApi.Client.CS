using System;
using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory;

namespace TradingApi.Client.Framework.Tests.StreamingTests.LightStreamerTests.ConnectionTests
{
    [TestFixture]
    public class LightStreamerConnectionManagerTests
    {
        private const string CITYINDEXSTREAMING_ADAPTER = "CITYINDEXSTREAMING";
        private const string STREAMINGCLIENTACCOUNT_ADAPTER = "STREAMINGCLIENTACCOUNT";
        private const string STREAMING_URL = "http://couldbeanyurl";
        private ILsCityindexStreamingConnection _mockLsCityindexStreamingConnection;
        private ILsStreamingClientAccountConnection _mockLsStreamingClientAccountConnection;
        private LsCityindexStreamingConnectionFactory _mockLsCityindexStreamingConnectionFactory;
        private LsStreamingClientAccountConnectionFactory _mockLsStreamingClientAccountConnectionFactory;
        private IApiConnection _mockApiConnection;

        [SetUp]
        public void SetUp()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();

            _mockLsCityindexStreamingConnectionFactory = MockRepository.GenerateMock<LsCityindexStreamingConnectionFactory>();
            _mockLsStreamingClientAccountConnectionFactory = MockRepository.GenerateMock<LsStreamingClientAccountConnectionFactory>();

            _mockLsCityindexStreamingConnection = MockRepository.GenerateMock<ILsCityindexStreamingConnection>();
            _mockLsStreamingClientAccountConnection = MockRepository.GenerateMock<ILsStreamingClientAccountConnection>();
        }

        [Test]
        public void ConnectToCityindexStreamingAdapterConnectsWithTheCorrectParametersAndReturnsIt()
        {
            //Arrange
            Uri cityindexStreamingAdapterUsed = null;
            _mockLsCityindexStreamingConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(_mockLsCityindexStreamingConnection)
                .WhenCalled(x => cityindexStreamingAdapterUsed = (Uri)x.Arguments[0]);

            _mockLsCityindexStreamingConnection.Expect(x => x.Connect());
            
            // Act
            var lightStreamerConnectionManager = new LightStreamerConnectionManager(_mockApiConnection);
            lightStreamerConnectionManager.ConnectToCityindexStreamingAdapter(STREAMING_URL, _mockLsCityindexStreamingConnectionFactory);

            // Assert
            Assert.AreEqual(STREAMING_URL + "/" + CITYINDEXSTREAMING_ADAPTER, cityindexStreamingAdapterUsed.AbsoluteUri);

            Assert.AreEqual(_mockLsCityindexStreamingConnection, lightStreamerConnectionManager.LsCityindexStreamingConnection);
            Assert.IsTrue(lightStreamerConnectionManager.CityindexStreamingAdaterIsConnected);
            _mockLsCityindexStreamingConnectionFactory.VerifyAllExpectations();
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
        }

        [Test]
        public void ConnectToStreamingClientAccountAdapterConnectsWithTheCorrectParametersAndReturnsIt()
        {
            //Arrange
            Uri streamingClientAccountAdapterUsed = null;
            _mockLsStreamingClientAccountConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(_mockLsStreamingClientAccountConnection)
                .WhenCalled(x => streamingClientAccountAdapterUsed = (Uri)x.Arguments[0]);

            _mockLsStreamingClientAccountConnection.Expect(x => x.Connect());

            // Act
            var lightStreamerConnectionManager = new LightStreamerConnectionManager(_mockApiConnection);
            lightStreamerConnectionManager.ConnectToStreamingClientAccountAdapter(STREAMING_URL, _mockLsStreamingClientAccountConnectionFactory);

            // Assert
            Assert.AreEqual(STREAMING_URL + "/" + STREAMINGCLIENTACCOUNT_ADAPTER, streamingClientAccountAdapterUsed.AbsoluteUri);
            Assert.AreEqual(_mockLsStreamingClientAccountConnection, lightStreamerConnectionManager.LsStreamingClientAccountConnection);
            Assert.IsTrue(lightStreamerConnectionManager.StreamingClientAccountAdapterIsConnected);
            _mockLsStreamingClientAccountConnectionFactory.VerifyAllExpectations();
            _mockLsStreamingClientAccountConnection.VerifyAllExpectations();
        }

        [Test] 
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsInvalidOperationExceptionIfTryToConnectToCityindexStreamingAdapterTwice()
        {
            //Arrange
            _mockLsCityindexStreamingConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(_mockLsCityindexStreamingConnection)
                .Repeat.Any();

            _mockLsCityindexStreamingConnection.Expect(x => x.Connect())
                .Repeat.Once();

            // Act
            var lightStreamerConnectionManager = new LightStreamerConnectionManager(_mockApiConnection);
            //first call
            lightStreamerConnectionManager.ConnectToCityindexStreamingAdapter(STREAMING_URL, _mockLsCityindexStreamingConnectionFactory);
            //second call
            lightStreamerConnectionManager.ConnectToCityindexStreamingAdapter(STREAMING_URL, _mockLsCityindexStreamingConnectionFactory);

            // Assert
            _mockLsCityindexStreamingConnectionFactory.VerifyAllExpectations();
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsInvalidOperationExceptionIfTryToConnectToStreamingClientAccountAdapterTwice()
        {
            //Arrange
            _mockLsStreamingClientAccountConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(_mockLsStreamingClientAccountConnection)
                .Repeat.Any();

            _mockLsStreamingClientAccountConnection.Expect(x => x.Connect())
                .Repeat.Once();

            // Act
            var lightStreamerConnectionManager = new LightStreamerConnectionManager(_mockApiConnection);
            //first call
            lightStreamerConnectionManager.ConnectToStreamingClientAccountAdapter(STREAMING_URL, _mockLsStreamingClientAccountConnectionFactory);
            //second call
            lightStreamerConnectionManager.ConnectToStreamingClientAccountAdapter(STREAMING_URL, _mockLsStreamingClientAccountConnectionFactory);

            // Assert
            _mockLsStreamingClientAccountConnectionFactory.VerifyAllExpectations();
            _mockLsStreamingClientAccountConnection.VerifyAllExpectations();
        }
        
        [Test, ExpectedException(typeof(NullReferenceException))]
        public void ThrowsNullReferenceExceptionIfConnectToStreamingClientAccountAdapterReturnsNullConnection()
        {
            // Arrange
            _mockLsStreamingClientAccountConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(null);

            // Act
            new LightStreamerConnectionManager(_mockApiConnection).ConnectToStreamingClientAccountAdapter(STREAMING_URL, _mockLsStreamingClientAccountConnectionFactory);

            // Assert
            _mockLsStreamingClientAccountConnectionFactory.VerifyAllExpectations();
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void ThrowsNullReferenceExceptionIfConnectToCityindexStreamingAdapterReturnsNullConnection()
        {
            // Arrange
            _mockLsCityindexStreamingConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(null);

            // Act
            new LightStreamerConnectionManager(_mockApiConnection).ConnectToCityindexStreamingAdapter(STREAMING_URL, _mockLsCityindexStreamingConnectionFactory);

            // Assert
            _mockLsCityindexStreamingConnectionFactory.VerifyAllExpectations();
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void ReturnstheExceptionThrownByConnectToCityindexStreamingAdapter()
        {
            // Arrange
            _mockLsCityindexStreamingConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Throw(new InvalidOperationException());

            // Act
            new LightStreamerConnectionManager(_mockApiConnection).ConnectToCityindexStreamingAdapter(STREAMING_URL, _mockLsCityindexStreamingConnectionFactory);
        }

        [Test, ExpectedException(typeof(InvalidOperationException))]
        public void ReturnstheExceptionThrownByConnectToStreamingClientAccountAdapter()
        {
            // Arrange
            _mockLsStreamingClientAccountConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Throw(new InvalidOperationException());

            // Act
            new LightStreamerConnectionManager(_mockApiConnection).ConnectToStreamingClientAccountAdapter(STREAMING_URL, _mockLsStreamingClientAccountConnectionFactory);
        }

        [Test]
        public void LightStreamerConnectionManagerDisconnectCallsDisconnectOnTheConnectionsIfNotNull()
        {
            // Arrange
            // Create a valid lightstreamer connections
            _mockLsCityindexStreamingConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(_mockLsCityindexStreamingConnection);

            _mockLsStreamingClientAccountConnectionFactory.Expect(
                x => x.Create(Arg<Uri>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(_mockLsStreamingClientAccountConnection);

            _mockLsCityindexStreamingConnection.Expect(x => x.Disconnect()).Repeat.Once();
            _mockLsStreamingClientAccountConnection.Expect(x => x.Disconnect()).Repeat.Once();

            // Act
            var lightStreamerConnectionManager = new LightStreamerConnectionManager(_mockApiConnection);
            lightStreamerConnectionManager.ConnectToStreamingClientAccountAdapter(STREAMING_URL, _mockLsStreamingClientAccountConnectionFactory);
            lightStreamerConnectionManager.ConnectToCityindexStreamingAdapter(STREAMING_URL, _mockLsCityindexStreamingConnectionFactory);

            // Act - then disconnect
            lightStreamerConnectionManager.Disconnect();
            // this time we do not expect the lightstreamerClientConnection Disconnect to be called
            lightStreamerConnectionManager.Disconnect();

            // Assert
            Assert.IsFalse(lightStreamerConnectionManager.StreamingClientAccountAdapterIsConnected);
            Assert.IsFalse(lightStreamerConnectionManager.CityindexStreamingAdaterIsConnected);
            _mockLsCityindexStreamingConnectionFactory.VerifyAllExpectations();
            _mockLsStreamingClientAccountConnectionFactory.VerifyAllExpectations();
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
            _mockLsStreamingClientAccountConnection.VerifyAllExpectations();
        }
    }
}
