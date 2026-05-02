using POSShared.Entities;
using POSShared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSShared.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }
        public ICollection<SaleDetail> SaleDetails { get; set; }
    }

    public class SaleResponseDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal Subtotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public DateTime SaleDate { get; set; }
        public List<SaleDetailResponseDto> SaleDetails { get; set; }
    }

    public class SaleDetailResponseDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
