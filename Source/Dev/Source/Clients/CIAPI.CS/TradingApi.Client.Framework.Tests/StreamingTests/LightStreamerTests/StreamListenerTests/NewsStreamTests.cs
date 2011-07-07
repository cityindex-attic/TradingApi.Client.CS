using System;
using NUnit.Framework;
using Rhino.Mocks;
using StreamingClient;
using TradingApi.Client.Framework.DTOs;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Tests.StreamingTests.LightStreamerTests.StreamListenerTests
{
    [TestFixture]
    public class NewsStreamTests
    {
        private ILsCityindexStreamingConnection _mockLsCityindexStreamingConnection;
        private const string REGION = "UK";

        [SetUp]
        public void Setup()
        {
            _mockLsCityindexStreamingConnection = MockRepository.GenerateMock<ILsCityindexStreamingConnection>();
        }

        [Test]
        public void SubscribeToNewsBuildsTheNewsListenerCorrectlyStartsAndReturnsIt()
        {
            // Arrange
            var mockNewsListener = MockRepository.GenerateMock <IStreamingListener<NewsDTO>>();

            _mockLsCityindexStreamingConnection.Expect(x => x.BuildNewsHeadlinesListener("NEWS.HEADLINES." + REGION))
                .Return(mockNewsListener);

            mockNewsListener.Expect(x => x.Start());

            // Act
            new NewsStream(_mockLsCityindexStreamingConnection).SubscribeToNewsHeadlinesByRegion(REGION);

            // Assert
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
            mockNewsListener.VerifyAllExpectations();
        }

        [Test]
        public void ValidSubscribtionsAreAddedToAToNewsStreamListenerList()
        {
            // Arrange
            var mockNewsListener = MockRepository.GenerateMock<IStreamingListener<NewsDTO>>();

            _mockLsCityindexStreamingConnection.Expect(x => x.BuildNewsHeadlinesListener(Arg<string>.Is.Anything))
                .Return(mockNewsListener)
                .Repeat.Twice();

            // Act
            var newsStream = new NewsStream(_mockLsCityindexStreamingConnection);
            newsStream.SubscribeToNewsHeadlinesByRegion(REGION);
            newsStream.SubscribeToNewsHeadlinesByRegion("AnotherRegion");

            // Assert
            Assert.AreEqual(2, newsStream.Listeners.Count); 
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
            mockNewsListener.VerifyAllExpectations();
        }

        [Test]
        public void UnsubscribeStopsEachThePriceListener()
        {
            // Arrange
            var mockNewsListener = MockRepository.GenerateMock<IStreamingListener<NewsDTO>>();
            var mockNewsListener2 = MockRepository.GenerateMock<IStreamingListener<NewsDTO>>();

            _mockLsCityindexStreamingConnection.Expect(x => x.BuildNewsHeadlinesListener(Arg<string>.Is.Anything))
                .Return(mockNewsListener)
                .Repeat.Once();

            _mockLsCityindexStreamingConnection.Expect(x => x.BuildNewsHeadlinesListener(Arg<string>.Is.Anything))
                .Return(mockNewsListener2)
                .Repeat.Once();

            mockNewsListener.Expect(x => x.Stop());
            mockNewsListener2.Expect(x => x.Stop());

            // Act
            var newsStreamListener = new NewsStream(_mockLsCityindexStreamingConnection);
            newsStreamListener.SubscribeToNewsHeadlinesByRegion(REGION);
            newsStreamListener.SubscribeToNewsHeadlinesByRegion("anotherRegion");

            newsStreamListener.Unsubscribe();

            // Assert
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
            mockNewsListener.VerifyAllExpectations();
        }

    }
}
