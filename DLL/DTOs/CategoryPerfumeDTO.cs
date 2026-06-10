using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class CategoryPerfumeDTO : CategoryDTO
    {
        public List<PerfumeDTO> Perfumes { get; set; }

        public CategoryPerfumeDTO() 
        {
            Perfumes= new List<PerfumeDTO>();
        }
    }
}
