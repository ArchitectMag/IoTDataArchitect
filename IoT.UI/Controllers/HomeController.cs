using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Business.Interfaces;
using Core.Utilities.Result;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using Entities.ViewModels;

namespace IoT.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ILightService _lightServices;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, ILightService lightServices)
        {
            _logger = logger;
            _localizer = localizer;
            _lightServices = lightServices;
        }

        public async Task<IActionResult> Index()
        {
            IDataResult<List<Light>> model = await _lightServices.GetLightList();
            ViewData["hello"] = await Task.Run(() => _localizer["Hello"]);
            
            return View(model);
        }

        public IActionResult Privacy()
        {

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
