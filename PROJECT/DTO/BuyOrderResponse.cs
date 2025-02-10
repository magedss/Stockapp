using PROJECT.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PROJECT.DTO
{
    public class BuyOrderResponse
    {
       public Guid BuyOrderID { get; set; }
        [Required]
        public string StockSymbol { get; set; }
        [Required]
        public string StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        [Range(1, 100000)]
        public uint Quantity { get; set; }
        [Range(1, 100000)]
        public double Price { get; set; }
        public double TradeAmount { get; set; }
    }
    public static class BuyOrderExtension
    {
        public static  BuyOrderResponse ToResponse( this BuyOrder order)
        {
            return new BuyOrderResponse()
            {
                BuyOrderID = order.BuyOrderID,
                StockSymbol = order.StockSymbol,
                StockName = order.StockName,
                Price = order.Price,
                Quantity = order.Quantity,
                DateAndTimeOfOrder = order.DateAndTimeOfOrder,
                TradeAmount = order.Quantity * order.Price


            };

        }

    }
}
