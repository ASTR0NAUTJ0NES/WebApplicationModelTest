using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationModelTest.Models;

namespace WebApplicationModelTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult FizzBuzz()
        {
            return View("FizzBuzz");
        }

        [HttpPost]
        public IActionResult FizzBuzz(string fizz, string buzz)
        {
            var fizzBuzzModel = new FizzBuzzViewModel();
            fizzBuzzModel.FizzNum = Convert.ToInt32(fizz);
            fizzBuzzModel.BuzzNum = Convert.ToInt32(buzz);
            fizzBuzzModel.Output = $"You gave me FizzNum: {fizz} and BuzzNum {buzz}";
            return RedirectToAction("Result", fizzBuzzModel);
        }

        public IActionResult Result(FizzBuzzViewModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
