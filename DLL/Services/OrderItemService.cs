using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderItemService
    {
        DataAccessFactory factory;

        public OrderItemService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<OrderItemDTO> Get()
        {
            var Data = factory.OrderItemData().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<OrderItemDTO>>(Data);
            return ret;
        }
        public OrderItemDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<OrderItemDTO>(factory.OrderItemData().Get(id));
            
        }
        public bool Create(OrderItemDTO oi)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<OrderItem>(oi);
            return factory.OrderItemData().Create(data);
        }
        public bool Update(OrderItemDTO oi)
        {
            var mapper= MapperConfig.GetMapper();
            var data= mapper.Map<OrderItem>(oi);
            return factory.OrderItemData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.OrderItemData().Delete(id); 
        }
            }
}
