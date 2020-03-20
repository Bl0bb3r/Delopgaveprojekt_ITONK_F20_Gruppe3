using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;
using Microsoft.EntityFrameworkCore;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.AddDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            LoadDB();
        }

        public DbSet<Haandvaerker> Haandvaerkere { get; set; }
        public DbSet<Vaerktoej> Vaerktoejer { get; set; }
        public DbSet<Vaerktoejskasse> Vaerktoejskasser { get; set; }

        public void LoadDB()
        {
            List<Vaerktoejskasse> vaerktoej = new List<Vaerktoejskasse>
            {
                new Vaerktoejskasse {VTKFarve = "Roed"}
            };
            Haandvaerkere.Add(new Haandvaerker
            {
                HaandvaerkerID = 0, HVFornavn = "Brian", HVEfternavn = "Jacobsen", HVAnsaettelsedato = DateTime.Today,
                HVFagomraade = "Tømrer", Vaerktoejskasse = vaerktoej.ToHashSet()
            });
            Vaerktoejer.Add(new Vaerktoej
            {
                VTID = 0, VTFabrikat = "Dewalt", VTSerienr = "ABC1337XYZ", VTModel = "q49", VTType = "Boremaskine",
                VTAnskaffet = DateTime.Now, LiggerIvtk = 1
            });
        }
    }
}
