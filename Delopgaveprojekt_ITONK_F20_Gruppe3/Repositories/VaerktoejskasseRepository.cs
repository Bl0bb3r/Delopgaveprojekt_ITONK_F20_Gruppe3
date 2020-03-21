using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Repositories
{
    public class VaerktoejskasseRepository : IVaerktoejskasseRepository
    {
        private readonly AppDbContext.AppDbContext _dbContext;

        public VaerktoejskasseRepository(AppDbContext.AppDbContext context)
        {
            _dbContext = context;
        }

        public void AddVaerktøjskasse(Vaerktoejskasse vaerktoejskasse)
        {
            if(vaerktoejskasse != null)
            {
                _dbContext.Vaerktoejskasser.Add(vaerktoejskasse);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVaerktoejskasse(int id)
        {
            _dbContext.Vaerktoejskasser.Remove(_dbContext.Vaerktoejskasser.Find(id));
            _dbContext.SaveChanges();
        }

        public Vaerktoejskasse GetById(int id)
        {
            if(id != 0)
            {
                _dbContext.Vaerktoejskasser.Find(id);
            }
            return null;
        }

        public List<Vaerktoejskasse> GetVaerktoejskasse()
        {
            return _dbContext.Vaerktoejskasser.ToList();
        }

        public void UpdateVaerktoejskasse(int id)
        {
            _dbContext.Vaerktoejskasser.Update(_dbContext.Vaerktoejskasser.Find(id));
            _dbContext.SaveChanges();
        }
    }
}
