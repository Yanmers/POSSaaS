using POSShared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSShared.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public decimal Subtotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string? CustomerName { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
        public PaymentMethod PaymentMethod { get; set; }
        public bool IsCancelled { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
