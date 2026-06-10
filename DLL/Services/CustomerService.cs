using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CustomerService 
    {
        DataAccessFactory factory;

        public CustomerService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<CustomerDTO> Get()
        {
            var data = factory.CustomerData().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<CustomerDTO>>(data);
            return ret;
        }
        public CustomerDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<CustomerDTO>(factory.CustomerData().Get(id));
        }
        public bool Create(CustomerDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Customer>(c);
            return factory.CustomerData().Create(data);
        }
        public bool Update(CustomerDTO c)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Customer>(c);
            return factory.CustomerData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.CustomerData().Delete(id);
        }

        //other services
        public CustomerDTO FindByPhone(string phone)
        {
            var data = factory.CustomerFeature().FindByPhone(phone);
            return MapperConfig.GetMapper().Map<CustomerDTO>(data);
        }

        public List<CustomerDTO> SearchByName(string name)
        {
            var data = factory.CustomerFeature().SearchByName(name);
            return MapperConfig.GetMapper().Map<List<CustomerDTO>>(data);
        }

        public List<CustomerDTO> CustomersWithOrders()
        {
            var data = factory.CustomerFeature().CustomersWithOrders();
            return MapperConfig.GetMapper().Map<List<CustomerDTO>>(data);
        }

    }
}
