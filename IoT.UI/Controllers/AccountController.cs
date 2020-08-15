using Microsoft.AspNetCore.Mvc;

namespace IoT.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult LoginForm()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult RegisterForm()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        public IActionResult Logout()
        {

            return View("Logout", "Çektire çektire çektir git...");
        }
    }
}
