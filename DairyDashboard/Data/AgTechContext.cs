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
        public DbSet<MachineData> MachineData { get; set; }

        public DbSet<Electricity_Supply> Electricity_Supply { get; set; }
        public DbSet<Electricity_Usage> Electricity_Usage { get; set; }

    }
}
