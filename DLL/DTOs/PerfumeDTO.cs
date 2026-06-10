using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class PerfumeDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int CategoryId {  get; set; }
    }
}
