//System
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyIoT.Api.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
