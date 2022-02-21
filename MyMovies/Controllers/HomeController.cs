using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = myContext.Categories.ToList();
            // return View("movieapp");

            // Using view bag to pass views
            return View();
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
            else //if invalid
            {

                ViewBag.Categories = myContext.Categories.ToList();
                return View(ar);
            }
        }

        //List View
        public IActionResult List()
        {
            var applications = myContext.Responses
                // .Where(x => x.edited == false)
                //.OrderBy(x => x.category)
                .Include(x => x.Category)
                .ToList()
                
                .ToList();
            
            return View(applications); // return list of applications
        }

        [HttpGet]
        public IActionResult Edit (int applicationid)
        {
            ViewBag.Categories = myContext.Categories.ToList();

            var application = myContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View("FillOutForm", application);
        }

        [HttpPost]
        public IActionResult Edit (ApplicationResponse blah)
        {
            myContext.Update(blah);
            myContext.SaveChanges();

            return RedirectToAction("List"); // gives info to List
        }

        [HttpGet]
        public IActionResult Delete (int applicationid)
        {
            var application = myContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            myContext.Responses.Remove(ar);
            myContext.SaveChanges();

            return RedirectToAction("List");
        }

        //podcast view
        public IActionResult Podcasts()
        {
            return View("Podcasts");
        }
       
    }
}
