using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPerfumeFeature
    {
        List<Perfume> SearchByName(string name);
        List<Perfume> FilterByPrice(decimal min, decimal max);
        List<Perfume> GetByCategory(int categoryId);
        List<Perfume> TopExpensive(int top);
    }
}
