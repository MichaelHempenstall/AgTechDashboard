using DairyDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DairyDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly AgTechContext _context;

        public HomeController(AgTechContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            using (var dbContext = new AgTechContext())
            {
                _context.Database.EnsureCreated();
            }

            var farms = _context.Farms.ToList();
            return View();
        }

        public List<Farm> GetFarms()
        {
            return _context.Farms.ToList();
        }
    }
}
