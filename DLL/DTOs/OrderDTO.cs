using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public int CustomerId { get; set; }
    }
}
