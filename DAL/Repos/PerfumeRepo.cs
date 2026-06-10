using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    public class PerfumeRepo : IRepository<Perfume>, IPerfumeFeature
    {
        PSMS db;
        public PerfumeRepo(PSMS db)
        {
            this.db = db;
        }
        public bool Create(Perfume p)
        {
            db.Perfumes.Add(p);
            return db.SaveChanges() > 0;

        }

        public List<Perfume> Get()
        {
            return db.Perfumes.ToList();

        }

        public Perfume Get(int id)
        {
            return db.Perfumes.Find(id);

        }

        public bool Update(Perfume P)
        {
            var ex = Get(P.Id);
            db.Entry(ex).CurrentValues.SetValues(P);
            return db.SaveChanges() > 0;

        }
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Perfumes.Remove(ex);
            return db.SaveChanges() > 0;

        }
        //Features
        public List<Perfume> SearchByName(string name)
        {
            return db.Perfumes
                .Where(p => p.Name.Contains(name))
                .ToList();
        }

        public List<Perfume> FilterByPrice(decimal min, decimal max)
        {
            return db.Perfumes
                .Where(p => p.Price >= min && p.Price <= max)
                .ToList();
        }

        public List<Perfume> GetByCategory(int categoryId)
        {
            return db.Perfumes
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public List<Perfume> TopExpensive(int top)
        {
            return db.Perfumes
                .OrderByDescending(p => p.Price)
                .Take(top)
                .ToList();
        }
    }
}
      