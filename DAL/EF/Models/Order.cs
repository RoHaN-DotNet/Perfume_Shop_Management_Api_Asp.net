using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Order
    {
       
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending";
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual List<OrderItem> Items { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }

    }
}
