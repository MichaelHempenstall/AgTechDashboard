using DairyDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace DairyDashboard
{
    public class AgTechContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Filename=Data\\AgTech.db");

        public DbSet<Student> Students { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineData> MachineDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farm>().ToTable("Farms");
            modelBuilder.Entity<Machine>().ToTable("Machines");
            modelBuilder.Entity<MachineData>().ToTable("MachineData");
        }

    }
}
