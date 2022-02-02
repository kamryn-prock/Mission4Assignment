using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieFormContext blahContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieFormContext someName)
        {
            _logger = logger;
            blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //get data
        public IActionResult FillOutForm()
        {
            return View("movieapp");
        }

        [HttpPost]
        //post data when valid
        public IActionResult FillOutForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                blahContext.Add(ar);
                blahContext.SaveChanges();

                return View("confirmation", ar);
            }
            else { 
                return View("movieapp",ar);
            }
        }

        //podcast view
        public IActionResult Podcasts()
        {
            return View("Podcasts");
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
