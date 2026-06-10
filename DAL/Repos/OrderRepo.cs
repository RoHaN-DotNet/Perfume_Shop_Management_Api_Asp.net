using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class OrderRepo : IRepository<Order>, IOrderFeature
    {
        PSMS db;
        public OrderRepo(PSMS db)
        {
            this.db = db;
        }
        public bool Create(Order o)
        {
            db.Orders.Add(o);
            return db.SaveChanges()>0;
        }
        public List<Order> Get()
        {
            return db.Orders.ToList();
        }
        public Order Get(int id)
        {
            return db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                .ThenInclude(i => i.Perfume)
                .FirstOrDefault(o => o.Id == id);
        }

        public bool Update(Order o)
        {
            var ex = Get(o.Id);
            db.Entry(ex).CurrentValues.SetValues(o);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex= Get(id);
            db.Orders.Remove(ex);
            return db.SaveChanges() > 0;
        }
        //Features
        public List<Order> GetByCustomer(int customerId)
        {
            return db.Orders.Where(o => o.CustomerId == customerId).ToList();
        }

        public List<OrderItem> GetItemsByOrder(int orderId)
        {
            return db.OrderItems.Where(oi => oi.OrderId == orderId).ToList();
        }

        public object SalesSummary()
        {
            var totalOrders = db.Orders.Count();
            var totalSales = db.Orders.Sum(o => o.TotalAmount);
            return new { totalOrders, totalSales };
        }
        public bool PlaceOrder(Order order, List<OrderItem> items)
        {
            // 1) Save order first
            db.Orders.Add(order);
            if (db.SaveChanges() <= 0) return false;

            // 2) order id assigned
            foreach (var it in items)
            {
                it.OrderId = order.Id;
                db.OrderItems.Add(it);
            }

            return db.SaveChanges() > 0;
        }

    }
}
