using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IOrderFeature
    {
        List<Order> GetByCustomer(int customerId);
        List<OrderItem> GetItemsByOrder(int orderId);
        object SalesSummary();

        bool PlaceOrder(Order order, List<OrderItem> items);

    }
}
