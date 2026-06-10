using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICategoryFeature
    {
        List<Category> GetWithPerfumes();

        Category GetWithPerfumes(int id);

        Category FindByName(string name);

        Category FindByNameWithProducts(string name);


    }
}
