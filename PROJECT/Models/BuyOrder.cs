using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models
{
    public class BuyOrder
    {
        Guid BuyOrderID { get; set; }
        [Required]
        string StockSymbol { get; set; }
        [Required]
        string StockName { get; set; }
        DateTime DateAndTimeOfOrder { get; set; }
        [Range(1, 100000)]
        uint Quantity { get; set; }
        [Range(1, 100000)]
        double Price { get; set; }
      
    }
}
