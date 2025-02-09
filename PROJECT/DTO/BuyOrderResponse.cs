using System.ComponentModel.DataAnnotations;

namespace PROJECT.DTO
{
    public class BuyOrderResponse
    {
        Guid SellOrderID { get; set; }
        [Required]
        string StockSymbol { get; set; }
        [Required]
        string StockName { get; set; }
        DateTime DateAndTimeOfOrder { get; set; }
        [Range(1, 100000)]
        uint Quantity { get; set; }
        [Range(1, 100000)]
        double Price { get; set; }
        double TradeAmount { get; set; }
    }
}
