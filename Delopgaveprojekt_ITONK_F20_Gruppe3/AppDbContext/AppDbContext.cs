using System;
using System.Collections.Generic;
using System.Linq;
using Delopgaveprojekt_ITONK_F20_Gruppe3.Models;
using Microsoft.EntityFrameworkCore;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Haandvaerker> Haandvaerkere { get; set; }
        public DbSet<Vaerktoej> Vaerktoejer { get; set; }
        public DbSet<Vaerktoejskasse> Vaerktoejskasser { get; set; }
    }
}
