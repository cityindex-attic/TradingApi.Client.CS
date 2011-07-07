using System;

namespace TradingApi.Client.Framework.Services
{
    public class ServiceManager
    {
        private IApiConnection _apiConnection;
        private MarketInfoServiceFactory _marketInfoServiceFactory;
        private AccountInfoServiceFactory _accountInfoServiceFactory;
        private CfdMarketServiceFactory _cfdMarketServiceFactory;
        private OrderServiceFactory _orderServiceFactory;
        private MarketInfoService _marketInfoService;
        private AccountInfoService _accountInfoService;
        private CfdMarketService _cfdMarketService;
        private OrderService _orderService;

        internal ServiceManager(){}

        internal ServiceManager(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        internal void SetUpServiceManagerForMocking(IApiConnection apiConnection, MarketInfoServiceFactory marketInfoServiceFactory, AccountInfoServiceFactory accountInfoServiceFactory, CfdMarketServiceFactory cfdMarketServiceFactory, OrderServiceFactory orderServiceFactory)
        {
            _apiConnection = apiConnection;
            _marketInfoServiceFactory = marketInfoServiceFactory;
            _accountInfoServiceFactory = accountInfoServiceFactory;
            _cfdMarketServiceFactory = cfdMarketServiceFactory;
            _orderServiceFactory = orderServiceFactory;
        }

        public MarketInfoService MarketInfoService
        {
            get
            {
                if (_marketInfoService != null) return _marketInfoService;

                if (_marketInfoServiceFactory == null)
                    _marketInfoServiceFactory = new MarketInfoServiceFactory();
                _marketInfoService = _marketInfoServiceFactory.Create(_apiConnection);

                return _marketInfoService;
            }
        }

        public AccountInfoService AccountInfoService
        {
            get
            {
                if (_accountInfoService != null) return _accountInfoService;

                if (_accountInfoServiceFactory == null)
                    _accountInfoServiceFactory = new AccountInfoServiceFactory();
                _accountInfoService = _accountInfoServiceFactory.Create(_apiConnection);

                return _accountInfoService;
            }
        }

        public CfdMarketService CfdMarketService
        {
            get
            {
                if (_cfdMarketService != null) return _cfdMarketService;

                if (_cfdMarketServiceFactory == null)
                    _cfdMarketServiceFactory = new CfdMarketServiceFactory();
                _cfdMarketService = _cfdMarketServiceFactory.Create(_apiConnection);

                return _cfdMarketService;
            }
        }

        public OrderService OrderService
        {
            get
            {
                if (_orderService != null) return _orderService;

                if (_orderServiceFactory == null)
                    _orderServiceFactory = new OrderServiceFactory();
                _orderService = _orderServiceFactory.Create(_apiConnection);

                return _orderService;
            }
        }
    }
}
