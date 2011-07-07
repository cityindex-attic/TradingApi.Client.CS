using System;
using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Streaming;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;

namespace TradingApi.Client.Framework.Tests.StreamingTests
{
    [TestFixture]
    public class StreamingManagerTests
    {
        private IApiConnection _mockApiConnection;
        private LightStreamerConnectionManager _mockLightStreamerConnectionManager;
        private StreamingManager _streamingManager;

        [SetUp]
        public void SetUp()
        {
            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
            _mockLightStreamerConnectionManager = MockRepository.GenerateMock<LightStreamerConnectionManager>(_mockApiConnection);
            _streamingManager = new StreamingManager(_mockLightStreamerConnectionManager);
        }
        
        [Test]
        public void StreamingManagerDisconnectCallsDisconnectOnTheLightStreamerConnectionManager()
        {
            // Arrange
            _mockLightStreamerConnectionManager.Expect(x => x.Disconnect());
            
            // Act - then disconnect
            _streamingManager.Disconnect();
            
            // Assert
            _mockLightStreamerConnectionManager.VerifyAllExpectations();
        }
        
        [Test, ExpectedException(typeof(InvalidProgramException))]
        public void DisconnectReturnsAnyErrorsThrownByDisconnectingTheStreamingConnections()
        {
            // Arrange
            _mockLightStreamerConnectionManager.Expect(x => x.Disconnect()).Throw(new InvalidProgramException());

            // Act
            _streamingManager.Disconnect();
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void NullReferenceExceptionThrownIfStreamingUrlIsNotSetBeforeStreamsPropertyIsCalled()
        {
            // Act
            var streams = _streamingManager.Streams;
        }

        [Test]
        public void StreamsPropertyLoadsTheFirstTimeItsCalled()
        {
            //Arrange
            _streamingManager.StreamingUrl = "couldBeAnyThing";

            // Act
            var streams = _streamingManager.Streams;
            var streamsSecondCall = _streamingManager.Streams;

            // Assert
            Assert.IsNotNull(streams);
            Assert.AreEqual(streams, streamsSecondCall);
        }
    }
}
