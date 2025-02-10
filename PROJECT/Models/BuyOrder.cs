﻿using PROJECT.DTO;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models
{
    public class BuyOrder
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

      
    }
}
