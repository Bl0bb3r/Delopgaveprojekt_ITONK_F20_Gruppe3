using Delopgaveprojekt_ITONK_F20_Gruppe3_Frontend.Models;
using Microsoft.EntityFrameworkCore;

namespace Delopgaveprojekt_ITONK_F20_Gruppe3_Frontend.AppDbFrontendContext
{
    public class AppDbFrontendContext : DbContext
    {
        public AppDbFrontendContext(DbContextOptions<AppDbFrontendContext> options)
            : base(options)
        {

        }

        public DbSet<Haandvaerker> Haandvaerkere { get; set; }

        public DbSet<Vaerktoej> Vaerktoej { get; set; }

        public DbSet<Vaerktoejskasse> Vaerktoejskasser { get; set; }



    }
}
