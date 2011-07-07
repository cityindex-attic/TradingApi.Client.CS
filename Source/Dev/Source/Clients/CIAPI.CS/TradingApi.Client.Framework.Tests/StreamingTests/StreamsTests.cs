using System;
using NUnit.Framework;
using Rhino.Mocks;
using TradingApi.Client.Framework.Streaming;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamFactory;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Tests.StreamingTests
{
    [TestFixture]
    public class StreamsTests
    {
        private IStreamingManager _mockStreamingManager;
        private IPriceStreamFactory _mockPriceStreamFactory;
        private INewsStreamFactory _mockNewsStreamFactory;
        private IOrderStreamFactory _mockOrderStreamFactory;
        private Streams _streams;
        private ILsCityindexStreamingConnection _mockLsCityindexStreamingConnection;
        private ILsStreamingClientAccountConnection _mockLStreamingClientAccountConnection;
        private LightStreamerConnectionManager _mockLightStreamerConnectionManager;
        private IApiConnection _mockApiConnection;
        private const string STREAMING_URL = "streamingUrl";

        [SetUp]
        public void SetUp()
        {
            _mockStreamingManager = MockRepository.GenerateMock<IStreamingManager>();
            _mockPriceStreamFactory = MockRepository.GenerateMock<IPriceStreamFactory>();
            _mockNewsStreamFactory = MockRepository.GenerateMock<INewsStreamFactory>();
            _mockOrderStreamFactory = MockRepository.GenerateMock<IOrderStreamFactory>();

            _streams = new Streams(_mockStreamingManager, _mockPriceStreamFactory, _mockNewsStreamFactory, _mockOrderStreamFactory);

            _mockLsCityindexStreamingConnection = MockRepository.GenerateMock<ILsCityindexStreamingConnection>();
            _mockLStreamingClientAccountConnection = MockRepository.GenerateMock<ILsStreamingClientAccountConnection>();

            _mockApiConnection = MockRepository.GenerateMock<IApiConnection>();
            _mockLightStreamerConnectionManager = MockRepository.GenerateMock<LightStreamerConnectionManager>(_mockApiConnection);
        }

        [Test]
        public void PriceStreamPropertyConnectsToTheCityIndexStreamingAdapterTheFirstTimeItsCalled()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager)
                .Return(_mockLightStreamerConnectionManager)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsCityindexStreamingConnection)
                .Return(_mockLsCityindexStreamingConnection)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.CityindexStreamingAdaterIsConnected)
                .Return(false);

            _mockStreamingManager.Expect(x => x.StreamingUrl).Return(STREAMING_URL);

            string streamingUrlUsed = "";
            _mockLightStreamerConnectionManager.Expect(x => x.ConnectToCityindexStreamingAdapter(Arg<string>.Is.Anything,
                                                     Arg<LsCityindexStreamingConnectionFactory>.Is.Anything))
                                                     .Repeat.Once()
                                                     .WhenCalled(x => streamingUrlUsed = (string)x.Arguments[0]);

            // Act
            var priceStream = _streams.PriceStream;

            // Assert
            Assert.AreEqual(STREAMING_URL, streamingUrlUsed);
            _mockStreamingManager.VerifyAllExpectations();
            _mockLightStreamerConnectionManager.VerifyAllExpectations();
        }

        [Test]
        public void PriceStreamPropertyDoesNotTryToConnectsToTheCityIndexStreamingAdapterIfAlreadyConnected()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager)
                .Return(_mockLightStreamerConnectionManager)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsCityindexStreamingConnection)
                .Return(_mockLsCityindexStreamingConnection)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.CityindexStreamingAdaterIsConnected)
                .Return(true);

            // Act
            var priceStream = _streams.PriceStream;

            // Assert
            _mockLightStreamerConnectionManager.AssertWasNotCalled(x => x.ConnectToCityindexStreamingAdapter(Arg<string>.Is.Anything,
                                                          Arg<LsCityindexStreamingConnectionFactory>.Is.Anything));
            _mockStreamingManager.VerifyAllExpectations();
            _mockLightStreamerConnectionManager.VerifyAllExpectations();
        }

        [Test]
        public void PriceStreamPropertyLazyLoadsTheFirstTimeItsCalled()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager).Return(
                _mockLightStreamerConnectionManager).Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsCityindexStreamingConnection).Return(
                _mockLsCityindexStreamingConnection).Repeat.Any();

            var expectedPriceStream = MockRepository.GenerateMock<PriceStream>(_mockLsCityindexStreamingConnection);

            _mockPriceStreamFactory.Expect(x => x.Create(_mockLsCityindexStreamingConnection))
                .Return(expectedPriceStream);

            // Act
            var priceStream = _streams.PriceStream;
            var priceStreamSecondCall = _streams.PriceStream;

            // Assert
            Assert.IsNotNull(priceStream);
            Assert.AreEqual(priceStream, priceStreamSecondCall);
            _mockPriceStreamFactory.VerifyAllExpectations();
        }

        [Test]
        public void NewsStreamPropertyConnectsToTheCityIndexStreamingAdapterTheFirstTimeItsCalled()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager)
                .Return(_mockLightStreamerConnectionManager)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsCityindexStreamingConnection)
                .Return(_mockLsCityindexStreamingConnection)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.CityindexStreamingAdaterIsConnected)
                .Return(false);

            _mockStreamingManager.Expect(x => x.StreamingUrl).Return(STREAMING_URL);

            string streamingUrlUsed = "";
            _mockLightStreamerConnectionManager.Expect(x => x.ConnectToCityindexStreamingAdapter(Arg<string>.Is.Anything,
                                                     Arg<LsCityindexStreamingConnectionFactory>.Is.Anything))
                                                     .Repeat.Once()
                                                     .WhenCalled(x => streamingUrlUsed = (string)x.Arguments[0]);

            // Act
            var newsStream = _streams.NewsStream;

            // Assert
            Assert.AreEqual(STREAMING_URL, streamingUrlUsed);
            _mockStreamingManager.VerifyAllExpectations();
            _mockLightStreamerConnectionManager.VerifyAllExpectations();
        }

        [Test]
        public void NewsStreamPropertyDoesNotTryToConnectsToTheCityIndexStreamingAdapterIfAlreadyConnected()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager)
                .Return(_mockLightStreamerConnectionManager)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsCityindexStreamingConnection)
                .Return(_mockLsCityindexStreamingConnection)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.CityindexStreamingAdaterIsConnected)
                .Return(true);

            // Act
            var newsStream = _streams.NewsStream;

            // Assert
            _mockLightStreamerConnectionManager.AssertWasNotCalled(x => x.ConnectToCityindexStreamingAdapter(Arg<string>.Is.Anything,
                                                          Arg<LsCityindexStreamingConnectionFactory>.Is.Anything));
            _mockStreamingManager.VerifyAllExpectations();
            _mockLightStreamerConnectionManager.VerifyAllExpectations();
        }

        [Test]
        public void NewsStreamPropertyLazyLoadsTheFirstTimeItsCalled()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager).Return(
                _mockLightStreamerConnectionManager)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsCityindexStreamingConnection).Return(
                _mockLsCityindexStreamingConnection)
                .Repeat.Any();

            var expectedNewsStream = MockRepository.GenerateMock<NewsStream>(_mockLsCityindexStreamingConnection);

            _mockNewsStreamFactory.Expect(x => x.Create(_mockLsCityindexStreamingConnection))
                .Return(expectedNewsStream);

            // Act
            var newsStream = _streams.NewsStream;
            var newsStreamSecondCall = _streams.NewsStream;

            // Assert
            Assert.IsNotNull(newsStream);
            Assert.AreEqual(newsStream, newsStreamSecondCall);
            _mockNewsStreamFactory.VerifyAllExpectations();
        }

        [Test]
        public void OrderStreamPropertyConnectsToTheStreamingClientAccountAdapterTheFirstTimeItsCalled()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager)
                .Return(_mockLightStreamerConnectionManager)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsStreamingClientAccountConnection)
                .Return(_mockLStreamingClientAccountConnection)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.StreamingClientAccountAdapterIsConnected)
                .Return(false);

            _mockStreamingManager.Expect(x => x.StreamingUrl).Return(STREAMING_URL);

            string streamingUrlUsed = "";
            _mockLightStreamerConnectionManager.Expect(x => x.ConnectToStreamingClientAccountAdapter(Arg<string>.Is.Anything,
                                                     Arg<LsStreamingClientAccountConnectionFactory>.Is.Anything))
                                                     .Repeat.Once()
                                                     .WhenCalled(x => streamingUrlUsed = (string)x.Arguments[0]);

            // Act
            var orderStream = _streams.OrderStream;

            // Assert
            Assert.AreEqual(STREAMING_URL, streamingUrlUsed);
            _mockStreamingManager.VerifyAllExpectations();
            _mockLightStreamerConnectionManager.VerifyAllExpectations();
        }

        [Test]
        public void OrderStreamPropertyDoesNotTryToConnectsToTheStreamingClientAccountAdapterIfAlreadyConnected()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager)
                .Return(_mockLightStreamerConnectionManager)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsStreamingClientAccountConnection)
                .Return(_mockLStreamingClientAccountConnection)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.StreamingClientAccountAdapterIsConnected)
                .Return(true);

            // Act
            var orderStream = _streams.OrderStream;

            // Assert
            _mockLightStreamerConnectionManager.AssertWasNotCalled(x => x.ConnectToStreamingClientAccountAdapter(Arg<string>.Is.Anything,
                                                          Arg<LsStreamingClientAccountConnectionFactory>.Is.Anything));
            _mockStreamingManager.VerifyAllExpectations();
            _mockLightStreamerConnectionManager.VerifyAllExpectations();
        }

        [Test]
        public void OrderStreamPropertyLazyLoadsTheFirstTimeItsCalled()
        {
            //Arrange
            _mockStreamingManager.Expect(x => x.LightStreamerConnectionManager).Return(
                _mockLightStreamerConnectionManager)
                .Repeat.Any();

            _mockLightStreamerConnectionManager.Expect(x => x.LsStreamingClientAccountConnection).Return(
                _mockLStreamingClientAccountConnection)
                .Repeat.Any();

            var expectedOrderStream = MockRepository.GenerateMock<OrderStream>(_mockLStreamingClientAccountConnection);

            _mockOrderStreamFactory.Expect(x => x.Create(_mockLStreamingClientAccountConnection))
                .Return(expectedOrderStream);

            // Act
            var orderStream = _streams.OrderStream;
            var orderStreamSecondCall = _streams.OrderStream;

            // Assert
            Assert.IsNotNull(orderStream);
            Assert.AreEqual(orderStream, orderStreamSecondCall);
            _mockOrderStreamFactory.VerifyAllExpectations();
        }
    }
}
