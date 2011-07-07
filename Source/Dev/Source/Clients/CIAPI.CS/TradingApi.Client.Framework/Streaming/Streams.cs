using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TradingApi.Client.Framework.Streaming.LightStreamer.Connection.Factory;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamFactory;
using TradingApi.Client.Framework.Streaming.LightStreamer.StreamListener;

namespace TradingApi.Client.Framework.Streaming
{
    public class Streams
    {
        private readonly IStreamingManager _streamingManager;
        private PriceStream _priceStream;
        private IPriceStreamFactory _priceStreamFactory;
        private NewsStream _newsStream;
        private INewsStreamFactory _newsStreamFactory;
        private OrderStream _orderStream;
        private IOrderStreamFactory _orderStreamFactory;

        internal Streams(IStreamingManager streamingManager)
        {
            _streamingManager = streamingManager;
        }

        internal Streams(IStreamingManager streamingManager, IPriceStreamFactory priceStreamFactory, INewsStreamFactory newsStreamFactory, IOrderStreamFactory orderStreamFactory)
        {
            _streamingManager = streamingManager;
            _priceStreamFactory = priceStreamFactory;
            _newsStreamFactory = newsStreamFactory;
            _orderStreamFactory = orderStreamFactory;
        }
        
        public PriceStream PriceStream
        {
            get
            {
                if (!_streamingManager.LightStreamerConnectionManager.CityindexStreamingAdaterIsConnected)
                    _streamingManager.LightStreamerConnectionManager.ConnectToCityindexStreamingAdapter(_streamingManager.StreamingUrl, new DefaultCityindexStreamingConnectionFactory());

                if (_priceStream != null) return _priceStream;

                if (_priceStreamFactory == null)
                    _priceStreamFactory = new PriceStreamFactory();
                _priceStream = _priceStreamFactory.Create(_streamingManager.LightStreamerConnectionManager.LsCityindexStreamingConnection);

                return _priceStream;
            }
        }

        public NewsStream NewsStream
        {
            get
            {
                if (!_streamingManager.LightStreamerConnectionManager.CityindexStreamingAdaterIsConnected)
                    _streamingManager.LightStreamerConnectionManager.ConnectToCityindexStreamingAdapter(_streamingManager.StreamingUrl, new DefaultCityindexStreamingConnectionFactory());

                if (_newsStream != null) return _newsStream;

                if (_newsStreamFactory == null)
                    _newsStreamFactory = new NewsStreamFactory();
                _newsStream = _newsStreamFactory.Create(_streamingManager.LightStreamerConnectionManager.LsCityindexStreamingConnection);

                return _newsStream;
            }
        }

        public OrderStream OrderStream
        {
            get
            {
                if (!_streamingManager.LightStreamerConnectionManager.StreamingClientAccountAdapterIsConnected)
                    _streamingManager.LightStreamerConnectionManager.ConnectToStreamingClientAccountAdapter(_streamingManager.StreamingUrl, new DefaultStreamingClientAccountConnectionFactory());
                
                if (_orderStream != null) return _orderStream;

                if (_newsStreamFactory == null)
                    _orderStreamFactory = new OrderStreamFactory();
                _orderStream = _orderStreamFactory.Create(_streamingManager.LightStreamerConnectionManager.LsStreamingClientAccountConnection);

                return _orderStream;
            }
        }
    }
}
