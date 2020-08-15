using Microsoft.AspNetCore.Mvc;

namespace IoT.UI.Areas.BackOffice.Controllers
{
    [Area("BackOffice")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }
    }
}