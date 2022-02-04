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
   
        private MovieFormContext myContext { get; set; }

        //Constructor
        public HomeController(MovieFormContext someName)
        {
            myContext = someName;
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
                myContext.Add(ar);
                myContext.SaveChanges();

                return View("confirmation", ar);
            }
            else { 
                return View("movieapp",ar);
            }
        }

        //List View
        public IActionResult List()
        {
            var applications = myContext.Responses
                // .Where(x => x.edited == false)
                //.OrderBy(x => x.category)
                .ToList()
                
                .ToList();
            
            return View(applications); // return list of applications
        }

        //podcast view
        public IActionResult Podcasts()
        {
            return View("Podcasts");
        }
       
    }
}
