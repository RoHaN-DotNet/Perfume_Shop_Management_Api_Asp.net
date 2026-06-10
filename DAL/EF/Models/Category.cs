using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        public virtual List<Perfume> Perfumes { get; set; } 
        public Category()
        {
            Perfumes= new List<Perfume>();
        }
    }
}
