using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderService
    {
        DataAccessFactory factory;

        public OrderService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<OrderDTO> Get()
        {
            var Data = factory.OrderData().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<OrderDTO>>(Data);
            return ret;
        }
        public OrderDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<OrderDTO>(factory.OrderData().Get(id));

        }
        public bool Create(OrderDTO o)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Order>(o);
            return factory.OrderData().Create(data);
        }
        public bool Update(OrderDTO o)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Order>(o);
            return factory.OrderData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.OrderData().Delete(id);
        }
        //other services
        public List<OrderDTO> GetByCustomer(int customerId)
        {
            var data = factory.OrderFeature().GetByCustomer(customerId);
            return MapperConfig.GetMapper().Map<List<OrderDTO>>(data);
        }

        public List<OrderItemDTO> GetItemsByOrder(int orderId)
        {
            var data = factory.OrderFeature().GetItemsByOrder(orderId);
            return MapperConfig.GetMapper().Map<List<OrderItemDTO>>(data);
        }

        public object SalesSummary()
        {
            return factory.OrderFeature().SalesSummary();
        }
        //Placeorder
        public bool PlaceOrder(OrderCreateDTO dto)
        {
            // 1) Basic validation
            if (dto.Items == null || dto.Items.Count == 0) return false;

            decimal total = 0;
            var items = new List<OrderItem>();

            foreach (var i in dto.Items)
            {
                var perfume = factory.PerfumeData().Get(i.PerfumeId);
                if (perfume == null) return false;

                // 2) Stock check
                if (perfume.Stock < i.Quantity) return false;

                // 3) Stock deduct
                perfume.Stock -= i.Quantity;
                factory.PerfumeData().Update(perfume);

                // 4) Price snapshot + total
                var unitPrice = perfume.Price;
                total += unitPrice * i.Quantity;

                items.Add(new OrderItem
                {
                    PerfumeId = perfume.Id,
                    Quantity = i.Quantity,
                    UnitPrice = unitPrice
                });
            }

            // 5) Create order
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                Status = "Completed",
                TotalAmount = total
            };

            // 6) Save order + items in one place
            return factory.OrderFeature().PlaceOrder(order, items);
        }

    }
}
