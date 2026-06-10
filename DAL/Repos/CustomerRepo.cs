using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class CustomerRepo : IRepository<Customer>,ICustomerFeature
    {
        PSMS db;
        public CustomerRepo(PSMS db)
        {
            this.db = db;
        }

        public bool Create(Customer c)
        {
            db.Customers.Add(c);
            return db.SaveChanges() > 0;
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public bool Update(Customer c)
        {
            var ex = Get(c.Id);
            db.Entry(ex).CurrentValues.SetValues(c);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Customers.Remove(ex);
            return db.SaveChanges() > 0;
        }
        //Features
        public Customer FindByPhone(string phone)
        {
            return db.Customers.FirstOrDefault(c => c.Phone == phone);
        }

        public List<Customer> SearchByName(string name)
        {
            return db.Customers
                .Where(c => c.Name.Contains(name))
                .ToList();
        }

        public List<Customer> CustomersWithOrders()
        {
            // CustomerId list from Orders
            var ids = db.Orders.Select(o => o.CustomerId).Distinct().ToList();
            return db.Customers.Where(c => ids.Contains(c.Id)).ToList();
        }
    }
}
