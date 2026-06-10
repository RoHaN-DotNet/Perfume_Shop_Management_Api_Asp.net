using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDTO>().ReverseMap();
            cfg.CreateMap<Perfume, PerfumeDTO>().ReverseMap();
            cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
            cfg.CreateMap<Order, OrderDTO>().ReverseMap();
            cfg.CreateMap<OrderItem, OrderItemDTO>().ReverseMap();


            cfg.CreateMap<Category, CategoryPerfumeDTO>().ReverseMap();

        });
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }
    }
}
