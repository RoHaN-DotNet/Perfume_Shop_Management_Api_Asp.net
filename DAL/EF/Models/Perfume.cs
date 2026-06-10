using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.EF.Models
{
    public class Perfume
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        [ForeignKey("Category")]

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
