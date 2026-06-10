using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICustomerFeature
    {
        Customer FindByPhone(string phone);
        List<Customer> SearchByName(string name);
        List<Customer> CustomersWithOrders();
    }
}
