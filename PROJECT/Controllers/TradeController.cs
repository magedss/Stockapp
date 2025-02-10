using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PROJECT.DTO;
using PROJECT.Models;
using PROJECT.ServiceContracts;
using PROJECT.Services;
using PROJECT.ViewModel;

namespace PROJECT.Controllers
{
    [Route("[controller]")]
    public class TradeController : Controller
    {

        private readonly IFinnhubService _finnhubService;
        private readonly IStocksService _stocksService;
        private readonly IConfiguration _configuration;
        private Task<List<BuyOrderResponse>> _buyOrders;

        public TradeController( IFinnhubService finnhubService, IStocksService stocksService,IConfiguration configuration)
        {

            _finnhubService = finnhubService;
            _stocksService = stocksService;
            _configuration = configuration;
        }
        [Route("index")]
        [Route("/")]
        public IActionResult Index()
        {
            var PriceQuote = _finnhubService.GetStockPriceQuote("MSFT");
            var CompanyProfile = _finnhubService.GetCompanyProfile("MSFT");

            CompanyProfile.Result.TryGetValue("name", out var name);
            PriceQuote.Result.TryGetValue("c", out var price);

            StockTrade stock = new StockTrade() { StockName = Convert.ToString(name), StockSymbol = "MSFT", Price =Convert.ToDouble( Convert.ToString( price)) };

            ViewBag.FinnhubToken = _configuration["FinnhubToken"];
            return View(stock);
        }
        [Route("[action]")]
        public IActionResult Orders()
        {
            var BuyOrders = _stocksService.GetBuyOrders();
            var SellOrders= _stocksService.GetSellOrders();
            OrdersCollection collection=new OrdersCollection();
            collection._buyOrders=BuyOrders.Result.ToList();
            collection._sellOrders = SellOrders.Result.ToList();

            return View(collection);
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult BuyOrder(BuyOrderRequest order)
        {
            order.DateAndTimeOfOrder = DateTime.Now;
            ModelState.Clear();
            TryValidateModel(order);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
                //request for nothing
            }
            _stocksService.CreateBuyOrder(order);

            return RedirectToAction("Orders");
            
        }
        [Route("[action]")]
        [HttpPost]
        public IActionResult SellOrder(SellOrderRequest order)
        {
            order.DateAndTimeOfOrder = DateTime.Now;
            ModelState.Clear();
            TryValidateModel(order);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
                //request for nothing
            }
            _stocksService.CreateSellOrder(order);

            return RedirectToAction("Orders");

        }
    }
}
