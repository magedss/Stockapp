using PROJECT.Models;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.DTO
{
    public class SellOrderRequest
    {
        [Required]
       public string StockSymbol { get; set; }
        [Required]
        public string StockName { get; set; }
        //check
        public DateTime DateAndTimeOfOrder { get; set; }
        [Range(1, 100000)]
        public uint Quantity { get; set; }
        [Range(1, 100000)]
        public double Price { get; set; }

        internal SellOrder ToSellOrder()
        {
            return new SellOrder { StockSymbol = this.StockSymbol, StockName = this.StockName, Price = this.Price, DateAndTimeOfOrder = this.DateAndTimeOfOrder, Quantity = this.Quantity };

        }
    }
}
