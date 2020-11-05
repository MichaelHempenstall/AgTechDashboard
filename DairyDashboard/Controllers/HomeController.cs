using DairyDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DairyDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            using (var dbContext = new DatabaseContext())
            {
                _context.Database.EnsureCreated();
            }

            var farms = _context.Farms.ToList();
            return View();
        }

        public List<Farms> GetFarms()
        {
            return _context.Farms.ToList();
        }
    }
}
