using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleEntityCore.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public int CategoryID { get; set; } // karena hanya ada ID dari tabel lain, maka hanya 1
        [Required]
        public string ProductName { get; set; }

        public string Stock { get; set; }
        public string BuyPrice { get; set; }
        public string SellPrice { get; set; }
        public DateTime ArrivalDate { get; set; }
        public Category Category { get; set; } 
    }
}
