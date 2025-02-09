using PROJECT.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PROJECT.DTO
{
    public class BuyOrderRequest
    {
      
        [Required]
        string StockSymbol { get; set; }
        [Required]
        string StockName { get; set; }
   //check
        DateTime DateAndTimeOfOrder { get; set; }
        [Range(1, 100000)]
        uint Quantity { get; set; }
        [Range(1, 100000)]
        double Price { get; set; }
    
    }
}
