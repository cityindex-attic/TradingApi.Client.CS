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
    public class OrderStreamTests
    {
        private const string ORDERS_TOPIC = "ORDERS";
        private ILsStreamingClientAccountConnection _mockLsStreamingClientAccountConnection;
        
        [SetUp]
        public void Setup()
        {
            _mockLsStreamingClientAccountConnection = MockRepository.GenerateMock<ILsStreamingClientAccountConnection>();
        }

        [Test]
        public void SubscribeToOrderBuildsTheOrderListenerCorrectlyStartsAndReturnsIt()
        {
            // Arrange
            var mockOrderListener = MockRepository.GenerateMock <IStreamingListener<OrderDTO>>();

            _mockLsStreamingClientAccountConnection.Expect(x => x.BuildOrderListener(ORDERS_TOPIC))
                .Return(mockOrderListener);

            mockOrderListener.Expect(x => x.Start());

            // Act
            new OrderStream(_mockLsStreamingClientAccountConnection).SubscribeToOrders();

            // Assert
            _mockLsStreamingClientAccountConnection.VerifyAllExpectations();
            mockOrderListener.VerifyAllExpectations();
        }

        [Test]
        public void ValidSubscribtionsAreAddedToAToOrderStreamListenerList()
        {
            // Arrange
            var mockOrderListener = MockRepository.GenerateMock<IStreamingListener<OrderDTO>>();

            _mockLsStreamingClientAccountConnection.Expect(x => x.BuildOrderListener(Arg<string>.Is.Anything))
                .Return(mockOrderListener)
                .Repeat.Twice();

            // Act
            var orderStream = new OrderStream(_mockLsStreamingClientAccountConnection);
            orderStream.SubscribeToOrders();
            orderStream.SubscribeToOrders();

            // Assert
            Assert.AreEqual(2, orderStream.Listeners.Count);
            _mockLsStreamingClientAccountConnection.VerifyAllExpectations();
            mockOrderListener.VerifyAllExpectations();
        }

        [Test]
        public void UnsubscribeStopsEachTheOrderListener()
        {
            // Arrange
            var mockOrderListener = MockRepository.GenerateMock<IStreamingListener<OrderDTO>>();
            var mockOrderListener2 = MockRepository.GenerateMock<IStreamingListener<OrderDTO>>();

            _mockLsStreamingClientAccountConnection.Expect(x => x.BuildOrderListener(Arg<string>.Is.Anything))
                .Return(mockOrderListener)
                .Repeat.Once();

            _mockLsStreamingClientAccountConnection.Expect(x => x.BuildOrderListener(Arg<string>.Is.Anything))
               .Return(mockOrderListener2)
               .Repeat.Once();

            mockOrderListener.Expect(x => x.Stop());
            mockOrderListener2.Expect(x => x.Stop());

            // Act
            var orderStream = new OrderStream(_mockLsStreamingClientAccountConnection);
            
            //Two subscribtions
            orderStream.SubscribeToOrders();
            orderStream.SubscribeToOrders();

            orderStream.Unsubscribe();

            // Assert
            _mockLsStreamingClientAccountConnection.VerifyAllExpectations();
            mockOrderListener.VerifyAllExpectations();
            mockOrderListener2.VerifyAllExpectations();
        }
    }
}
