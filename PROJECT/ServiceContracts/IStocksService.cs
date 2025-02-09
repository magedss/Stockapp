using PROJECT.DTO;

namespace PROJECT.ServiceContracts
{
    public interface IStocksService
    {

        Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);

        Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest);

        Task<List<BuyOrderResponse>> GetBuyOrders();

        Task<List<SellOrderResponse>> GetSellOrders();

    }
}
