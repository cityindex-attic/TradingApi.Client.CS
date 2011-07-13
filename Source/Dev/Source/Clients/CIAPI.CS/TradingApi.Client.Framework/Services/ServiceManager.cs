using System;

namespace TradingApi.Client.Framework.Services
{
    public class ServiceManager
    {
        private IApiConnection _apiConnection;
        private MarketInformationServiceFactory _marketInformationServiceFactory;
        private AccountInformationServiceFactory _accountInformationServiceFactory;
        private CfdMarketServiceFactory _cfdMarketServiceFactory;
        private OrderServiceFactory _orderServiceFactory;
        private FutureOptionServiceFactory _futureOptionServiceFactory;
        private MessageServiceFactory _messageServiceFactory;
        private NewsServiceFactory _newsServiceFactory;
        private SpreadMarketServiceFactory _spreadMarketServiceFactory;
        private MarketInformationService _marketInformationService;
        private AccountInformationService _accountInformationService;
        private CfdMarketService _cfdMarketService;
        private OrderService _orderService;
        private FutureOptionService _futureOptionService;
        private MessageService _messageService;
        private NewsService _newsService;
        private SpreadMarketService _spreadMarketService;

        internal ServiceManager(){}

        internal ServiceManager(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        internal void SetUpServiceManagerForMocking(IApiConnection apiConnection, MarketInformationServiceFactory marketInformationServiceFactory, AccountInformationServiceFactory accountInformationServiceFactory, CfdMarketServiceFactory cfdMarketServiceFactory, OrderServiceFactory orderServiceFactory, FutureOptionServiceFactory futureOptionServiceFactory, MessageServiceFactory messageServiceFactory, NewsServiceFactory newsServiceFactory, SpreadMarketServiceFactory spreadMarketServiceFactory)
        {
            _apiConnection = apiConnection;
            _marketInformationServiceFactory = marketInformationServiceFactory;
            _accountInformationServiceFactory = accountInformationServiceFactory;
            _cfdMarketServiceFactory = cfdMarketServiceFactory;
            _orderServiceFactory = orderServiceFactory;
            _futureOptionServiceFactory = futureOptionServiceFactory;
            _messageServiceFactory = messageServiceFactory;
            _newsServiceFactory = newsServiceFactory;
            _spreadMarketServiceFactory = spreadMarketServiceFactory;
        }

        public MarketInformationService MarketInformationService
        {
            get
            {
                if (_marketInformationService != null) return _marketInformationService;

                if (_marketInformationServiceFactory == null)
                    _marketInformationServiceFactory = new MarketInformationServiceFactory();
                _marketInformationService = _marketInformationServiceFactory.Create(_apiConnection);

                return _marketInformationService;
            }
        }

        public AccountInformationService AccountInformationService
        {
            get
            {
                if (_accountInformationService != null) return _accountInformationService;

                if (_accountInformationServiceFactory == null)
                    _accountInformationServiceFactory = new AccountInformationServiceFactory();
                _accountInformationService = _accountInformationServiceFactory.Create(_apiConnection);

                return _accountInformationService;
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

        public FutureOptionService FutureOptionService
        {
            get
            {
                if (_futureOptionService != null) return _futureOptionService;

                if (_futureOptionServiceFactory == null)
                    _futureOptionServiceFactory = new FutureOptionServiceFactory();
                _futureOptionService = _futureOptionServiceFactory.Create(_apiConnection);

                return _futureOptionService;
            }
        }

        public MessageService MessageService
        {
            get
            {
                if (_messageService != null) return _messageService;

                if (_messageServiceFactory == null)
                    _messageServiceFactory = new MessageServiceFactory();
                _messageService = _messageServiceFactory.Create(_apiConnection);

                return _messageService;
            }
        }

        public NewsService NewsService
        {
            get
            {
                if (_newsService != null) return _newsService;

                if (_newsServiceFactory == null)
                    _newsServiceFactory = new NewsServiceFactory();
                _newsService = _newsServiceFactory.Create(_apiConnection);

                return _newsService;
            }
        }

        public SpreadMarketService SpreadMarketService
        {
            get {
                if (_spreadMarketService != null) return _spreadMarketService;

                if(_spreadMarketServiceFactory == null)
                    _spreadMarketServiceFactory = new SpreadMarketServiceFactory();
                _spreadMarketService = _spreadMarketServiceFactory.Create(_apiConnection);

                return _spreadMarketService;
            }
            set {
                _spreadMarketService = value;
            }
        }
    }
}
