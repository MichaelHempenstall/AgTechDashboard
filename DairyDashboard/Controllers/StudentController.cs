using Microsoft.AspNetCore.Mvc;

namespace DairyDashboard.Controllers
{
    public class StudentController : Controller
    {
        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
