using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;
using Microsoft.EntityFrameworkCore;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.AddDbContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContext<AppDbContext> options) : base(options)
        {
            LoadDB();
        }

        public DbSet<Haandvaerker> Haandvaerkere { get; set; }
        public DbSet<Vaerktoej> Vaerktoejer { get; set; }
        public DbSet<Vaerktoejskasse> Vaerktoejskasser { get; set; }



    }
}
