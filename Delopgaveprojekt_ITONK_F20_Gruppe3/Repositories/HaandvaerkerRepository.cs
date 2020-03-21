using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.Repositories
{
    public class HaandvaerkerRepository : IHaandvaerkerRepository
    {
        private readonly AppDbContext.AppDbContext _dbContext;

        public HaandvaerkerRepository(AppDbContext.AppDbContext context)
        {
            _dbContext = context;
        }

        public void AddHaandvaerker(Haandvaerker haandvaerker)
        {
            if(haandvaerker != null)
            {
                _dbContext.Haandvaerkere.Add(haandvaerker);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteHaandvaerker(int id)
        {
            _dbContext.Haandvaerkere.Remove(_dbContext.Haandvaerkere.Find(id));
            _dbContext.SaveChanges();
        }

        public Haandvaerker GetById(int id)
        {
            if(id != 0)
            {
                return _dbContext.Haandvaerkere.Find(id);
            }

            return null;
        }

        public List<Haandvaerker> GetHaandvaerkers()
        {
            var haandvaerkere = new List<Haandvaerker>();
            try
            {
                haandvaerkere = _dbContext.Haandvaerkere.ToList();
            }
            catch(Exception e)
            {
                haandvaerkere.Add(new Haandvaerker
                {
                    HaandvaerkerID = 0,
                    HVAnsaettelsedato = DateTime.Now,
                    HVFornavn = "Could not access database",
                    HVEfternavn = e.InnerException.ToString(),
                    HVFagomraade = e.Message
                });
            }
            return haandvaerkere;
        }

        public void UpdateHaandvaerker(int id)
        {
            _dbContext.Haandvaerkere.Update(_dbContext.Haandvaerkere.Find(id));
            _dbContext.SaveChanges();
        }
    }
}
