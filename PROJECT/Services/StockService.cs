using PROJECT.DTO;
using PROJECT.Models;
using PROJECT.ServiceContracts;

namespace PROJECT.Services
{
    public class StockService : IStocksService
    {
        List<BuyOrder> _Buyorders; 
        List<SellOrder> _Sellorders;
        public StockService() {
            _Buyorders = new List<BuyOrder>();
            _Sellorders = new List<SellOrder>();
        }
        public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            //model verfication
            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
            buyOrder.BuyOrderID=Guid.NewGuid();
            _Buyorders.Add(buyOrder);
            return buyOrder.ToResponse();
        }

        public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            //model verfication
            SellOrder sellOrder = sellOrderRequest.ToSellOrder();
            sellOrder.SellOrderID = Guid.NewGuid();
            _Sellorders.Add(sellOrder);
         
            return sellOrder.ToResponse();
        }

        public async Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            var myList= new List<BuyOrderResponse>();
            foreach (var buyOrder in _Buyorders)
            {
                myList.Add(buyOrder.ToResponse());

            }
            return myList;
        }

        public async Task<List<SellOrderResponse>> GetSellOrders()
        {
            var myList = new List<SellOrderResponse>();
            foreach (var sellOrder in _Sellorders)
            {
                myList.Add(sellOrder.ToResponse());

            }
            return myList;
        }
    }
}
