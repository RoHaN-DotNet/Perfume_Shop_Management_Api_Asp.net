using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class PSMS :DbContext
    {
        public PSMS(DbContextOptions<PSMS> opt) : base(opt)
        {
        }
            public DbSet<Category> Categories { get; set; }

        public DbSet<Perfume> Perfumes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
