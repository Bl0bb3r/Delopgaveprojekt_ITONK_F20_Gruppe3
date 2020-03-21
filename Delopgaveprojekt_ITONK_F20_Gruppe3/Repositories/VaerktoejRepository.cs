using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Repositories
{
    public class VaerktoejRepository : IVaerktoejRepository
    {
        private readonly AppDbContext.AppDbContext _dbContext;

        public VaerktoejRepository(AppDbContext.AppDbContext context)
        {
            _dbContext = context;
        }

        public void AddVaerktoej(Vaerktoej vaerktoej)
        {
            _dbContext.Vaerktoejer.Add(vaerktoej);
            _dbContext.SaveChanges();
        }

        public void DeleteVaertoej(int id)
        {
            _dbContext.Vaerktoejer.Remove(_dbContext.Vaerktoejer.Find(id));
            _dbContext.SaveChanges();
        }

        public Vaerktoej GetById(int id)
        {
            if(id != 0)
            {
                _dbContext.Vaerktoejer.Find(id);
            }
            return null;
        }

        public List<Vaerktoej> GetVaerktoej()
        {
            return _dbContext.Vaerktoejer.ToList();
        }

        public void UpdateVaerktoej(int id)
        {
            _dbContext.Vaerktoejer.Update(_dbContext.Vaerktoejer.Find(id));
            _dbContext.SaveChanges();
        }
    }
}
