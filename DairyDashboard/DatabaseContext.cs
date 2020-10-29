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
    }
}
