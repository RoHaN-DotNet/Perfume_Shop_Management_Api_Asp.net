using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class OrderDetailsDTO: OrderDTO
    {
        public List<OrderItemDTO> Items { get; set; }
        public OrderDetailsDTO()
        {
            Items = new List<OrderItemDTO>();
        }
    }
}
