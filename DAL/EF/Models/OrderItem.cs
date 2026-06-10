using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Perfume")]
        public int PerfumeId { get; set; }
        public Perfume Perfume { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
