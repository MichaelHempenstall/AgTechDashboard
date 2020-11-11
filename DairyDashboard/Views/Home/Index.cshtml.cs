using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace DairyDashboard.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private readonly AgTechContext _context;
        public IndexModel(AgTechContext context)
        {
            _context = context;
        }

        public Models.Farm Farms { get; set; }
        public void OnGet()
        {
            //Farms = _context.Farms.ToList();
            //return Page();
        }
      
    }
}
