using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PROJECT.ServiceContracts;
using PROJECT.ViewModel;

namespace PROJECT.Controllers
{
    public class TradeController : Controller
    {

        private readonly IFinnhubService _finnhubService;
        private readonly IStocksService _stocksService;
        private readonly IConfiguration _configuration;

        public TradeController( IFinnhubService finnhubService, IStocksService stocksService,IConfiguration configuration)
        {

            _finnhubService = finnhubService;
            _stocksService = stocksService;
            _configuration = configuration;
        }
        [Route("/Trade/index")]
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
    }
}
