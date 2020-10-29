using DairyDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DairyDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _myDbContext = new DatabaseContext();

        public IActionResult Index()
        {
            using (var dbContext = new DatabaseContext())
            {
                dbContext.Database.EnsureCreated();
                if (!dbContext.Students.Any())
                {
                    dbContext.Students.AddRange(new Student[]
                        {
                            new Student{Id = 1, Name = "Ted" },
                            new Student{Id = 2, Name = "Joe" },
                        });
                    dbContext.SaveChanges();
                }
            }

            var oneStudent = _myDbContext.Students.First();
            return View(oneStudent);
        }
    }
}
