using DairyDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyDashboard
{
    public class DatabaseContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Database\\AgTech.db");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Farms> Farms { get; set; }
        public DbSet<Machines> Machines { get; set; }
        public DbSet<MachineData> MachineDatas { get; set; }

    }
}
