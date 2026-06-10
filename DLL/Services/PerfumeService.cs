using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PerfumeService
    {
        DataAccessFactory factory;

        public PerfumeService(DataAccessFactory factory)
        {
            this.factory = factory;
        }
        public List<PerfumeDTO> Get()
        {
            var Data = factory.PerfumeData().Get();
            var mapper = MapperConfig.GetMapper();
            var ret = mapper.Map<List<PerfumeDTO>>(Data);
            return ret;
        }
        public PerfumeDTO Get(int id)
        {
            return MapperConfig.GetMapper().Map<PerfumeDTO>(factory.PerfumeData().Get(id));

        }
        public bool Create(PerfumeDTO p)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Perfume>(p);
            return factory.PerfumeData().Create(data);
        }
        public bool Update(PerfumeDTO p)
        {
            var mapper = MapperConfig.GetMapper();
            var data = mapper.Map<Perfume>(p);
            return factory.PerfumeData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.PerfumeData().Delete(id);
        }
        //other Services
        public List<PerfumeDTO> SearchByName(string name)
        {
            var data = factory.PerfumeFeature().SearchByName(name);
            return MapperConfig.GetMapper().Map<List<PerfumeDTO>>(data);
        }

        public List<PerfumeDTO> FilterByPrice(decimal min, decimal max)
        {
            var data = factory.PerfumeFeature().FilterByPrice(min, max);
            return MapperConfig.GetMapper().Map<List<PerfumeDTO>>(data);
        }

        public List<PerfumeDTO> GetByCategory(int categoryId)
        {
            var data = factory.PerfumeFeature().GetByCategory(categoryId);
            return MapperConfig.GetMapper().Map<List<PerfumeDTO>>(data);
        }

        public List<PerfumeDTO> TopExpensive(int top)
        {
            var data = factory.PerfumeFeature().TopExpensive(top);
            return MapperConfig.GetMapper().Map<List<PerfumeDTO>>(data);
        }
    }
    
}
