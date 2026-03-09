using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSShared.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CurrentStock { get; set; }
        public int StockMininum { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool IsActive { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;


    }
}
