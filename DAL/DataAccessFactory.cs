using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DataAccessFactory
    {
        PSMS db;

        public DataAccessFactory(PSMS db) {

            this.db = db;
        }
        public IRepository<Category> CategoryData()
        {
            return new CategoryRepo(db);
        }
        public IRepository<Perfume> PerfumeData()
        {
            return new PerfumeRepo(db);
        }
        public IRepository<Order> OrderData()
        {
            return new OrderRepo(db);
        }
        public IRepository<OrderItem> OrderItemData()
        {
            return new OrderItemRepo(db);
        }
        public IRepository<Customer> CustomerData()
        {
            return new CustomerRepo(db);
        }
        //other feature
        public ICategoryFeature CategoryFeature()
        {
            return new CategoryRepo(db);
        }
        public IPerfumeFeature PerfumeFeature()
        {
            return new PerfumeRepo(db);
        }

        public ICustomerFeature CustomerFeature()
        {
            return new CustomerRepo(db);
        }

        public IOrderFeature OrderFeature()
        {
            return new OrderRepo(db);
        }
    }
}
