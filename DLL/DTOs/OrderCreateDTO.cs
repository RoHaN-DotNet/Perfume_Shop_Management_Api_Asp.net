using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class OrderCreateDTO
    {
        public int CustomerId { get; set; }
        public List<OrderItemCreateDTO> Items { get; set; }

        public OrderCreateDTO()
        {
            Items = new List<OrderItemCreateDTO>();
        }
    }
    public class OrderItemCreateDTO
    {
        public int PerfumeId { get; set; }
        public int Quantity { get; set; }
    }
}
