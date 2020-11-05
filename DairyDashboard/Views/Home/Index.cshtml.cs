using DairyDashboard.Controllers;
using DairyDashboard.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DairyDashboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //public JsonFileProductService ProductService;
        public IEnumerable<Models.Farms> Farms { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Farms = Farms.ToList();
            
        }
    }
}
