using PROJECT.Models;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.DTO
{
    public class SellOrderResponse
    {
       public Guid SellOrderID { get; set; }
        [Required]
     public   string StockSymbol { get; set; }
        [Required]
     public   string StockName { get; set; }
      public  DateTime DateAndTimeOfOrder { get; set; }
        [Range(1, 100000)]
      public  uint Quantity { get; set; }
        [Range(1, 100000)]
      public  double Price { get; set; }
       public double TradeAmount { get; set; }
    }
    public static class SellOrderExtension
    {
        public static SellOrderResponse ToResponse(this SellOrder order)
        {
            return new SellOrderResponse()
            {
                SellOrderID = order.SellOrderID,
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
