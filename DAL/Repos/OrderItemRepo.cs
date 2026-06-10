using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class OrderItemRepo : IRepository<OrderItem>
    {
        PSMS db;
        public OrderItemRepo(PSMS db)
        {
            this.db = db;
        }
        public bool Create(OrderItem oi)
        {
            db.OrderItems.Add(oi);
            return db.SaveChanges() > 0;
        }
        public List<OrderItem> Get()
        {
            return db.OrderItems.ToList();
        }
        public OrderItem Get(int id)
        {
            return db.OrderItems.Find(id);
        }
        public bool Update(OrderItem o)
        {
            var ex = Get(o.Id);
            db.Entry(ex).CurrentValues.SetValues(o);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.OrderItems.Remove(ex);
            return db.SaveChanges() > 0;
        }

        //Features
        
    }
}
