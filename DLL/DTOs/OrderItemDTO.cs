using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        
        
        public int PerfumeId { get; set; }
     

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
