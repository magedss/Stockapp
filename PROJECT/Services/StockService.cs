﻿using PROJECT.DTO;
using PROJECT.ServiceContracts;

namespace PROJECT.Services
{
    public class StockService : IStocksService
    {
        public Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            throw new NotImplementedException();
        }

        public Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            throw new NotImplementedException();
        }

        public Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            throw new NotImplementedException();
        }

        public Task<List<SellOrderResponse>> GetSellOrders()
        {
            throw new NotImplementedException();
        }
    }
}
