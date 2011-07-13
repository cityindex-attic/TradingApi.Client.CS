using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using StreamingClient;
using TradingApi.Client.Framework.DTOs;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Tests.StreamingTests.LightStreamerTests.StreamListenerTests
{
    [TestFixture]
    public class PriceStreamTests
    {
        private ILsCityindexStreamingConnection _mockLsCityindexStreamingConnection;
        private const string PRICES_TOPIC = "PRICES.PRICE.";

        [SetUp]
        public void Setup()
        {
            _mockLsCityindexStreamingConnection = MockRepository.GenerateMock<ILsCityindexStreamingConnection>();
        }

        [Test]
        public void SubscribeToMarketPriceBuildsThePriceListenerCorrectlyStartsAndReturnsIt()
        {
            // Arrange
            const int marketId = 1;
            var mockPriceListener = MockRepository.GenerateMock <IStreamingListener<PriceDTO>>();

            _mockLsCityindexStreamingConnection.Expect(x => x.BuildPriceListener(PRICES_TOPIC + marketId))
                .Return(mockPriceListener);

            // Act
            new PriceStream(_mockLsCityindexStreamingConnection).SubscribeToMarketPrice(marketId);

            // Assert
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
            mockPriceListener.VerifyAllExpectations();
        }

        [Test]
        public void SubscribeToMarketPriceListBuildsThePriceListenerCorrectlyStartsAndReturnsIt()
        {
            // Arrange
            const int marketIdOne = 1;
            const int marketIdTwo = 2;
            var marketIds = new List<int> { marketIdOne, marketIdTwo };

            var mockPriceListener = MockRepository.GenerateMock<IStreamingListener<PriceDTO>>();

            var topics = marketIds.Select(marketId => PRICES_TOPIC + marketId).ToList();

            _mockLsCityindexStreamingConnection.Expect(x => x.BuildPriceListener(topics))
                .Return(mockPriceListener);

            mockPriceListener.Expect(x => x.Start());

            // Act
            new PriceStream(_mockLsCityindexStreamingConnection).SubscribeToMarketPriceList(marketIds);

            // Assert
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
            mockPriceListener.VerifyAllExpectations();
        }

        [Test]
        public void ValidSubscribtionsAreAddedToAToNewsStreamListenerList()
        {
            // Arrange
            var mockPriceListener = MockRepository.GenerateMock<IStreamingListener<PriceDTO>>();

            _mockLsCityindexStreamingConnection.Expect(x => x.BuildPriceListener(Arg<string>.Is.Anything))
                .Return(mockPriceListener)
                .Repeat.Twice();

            // Act
            var priceStream = new PriceStream(_mockLsCityindexStreamingConnection);
            priceStream.SubscribeToMarketPrice(1);
            priceStream.SubscribeToMarketPrice(2);

            // Assert
            Assert.AreEqual(2, priceStream.Listeners.Count);
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
            mockPriceListener.VerifyAllExpectations();
        }

        [Test]
        public void UnsubscribeStopsEachThePriceListener()
        {
            // Arrange
            var mockPriceListener = MockRepository.GenerateMock<IStreamingListener<PriceDTO>>();
            var mockPriceListener2 = MockRepository.GenerateMock<IStreamingListener<PriceDTO>>();
            
            _mockLsCityindexStreamingConnection.Expect(x => x.BuildPriceListener(Arg<string>.Is.Anything))
                .Return(mockPriceListener)
                .Repeat.Once();

            _mockLsCityindexStreamingConnection.Expect(x => x.BuildPriceListener(Arg<List<string>>.Is.Anything))
               .Return(mockPriceListener2)
               .Repeat.Once();

            mockPriceListener.Expect(x => x.Stop());
            mockPriceListener2.Expect(x => x.Stop());

            // Act
            var priceStream = new PriceStream(_mockLsCityindexStreamingConnection);
            priceStream.SubscribeToMarketPrice(new int());
            priceStream.SubscribeToMarketPriceList(new List<int>());
            priceStream.Unsubscribe();

            // Assert
            _mockLsCityindexStreamingConnection.VerifyAllExpectations();
            mockPriceListener.VerifyAllExpectations();
            mockPriceListener2.VerifyAllExpectations();
        }
    }
}
