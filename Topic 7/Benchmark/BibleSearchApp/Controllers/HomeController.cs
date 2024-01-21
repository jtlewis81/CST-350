using BibleSearchApp.Models;
using BibleSearchApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibleSearchApp.Controllers
{
    public class HomeController : Controller
    {
        // service reference (returned by the Service mapping set up in Program.cs)
        IBibleService Service { get; set; }

        // constructor
        public HomeController(IBibleService service)
        {
            Service = service;
        }

        // default view
        public IActionResult Index()
        {
            return View();
        }

        // handle the search form action
        public IActionResult SearchResults(int option, string term)
        {
            // remove any non-alphabetical characters from the input
            term = Service.SanitizeInput(term);

            // if the resulting term is invalid
            if (string.IsNullOrEmpty(term))
            {
                // set option to -1 so we get the default case from the switch statement
                option = -1;
                // add an error message to be displayed to the user
                ViewBag.Error = "No results for empty or invalid input. Only letters, words, and spaces between them are allowed.";
            }
            else
            {
                // remove any error message if it is not needed
                ViewBag.Error = null;
            }

            // reset the list of results
            List<VerseModel> verses = new List<VerseModel>();
               
            // return the view with the appropriate search results based on the passed option parameter
            // this could also be handled in the service class but would be more complicated for getting the verse list count
            switch (option)
            {
                case 0:
                    verses = Service.SearchBible(term);
                    ViewBag.Message = Service.SanitizeInput(term);
                    ViewBag.Count = verses.Count;
                    return View("Index", verses);
                case 1:
                    verses = Service.SearchOT(term);
                    ViewBag.Message = Service.SanitizeInput(term);
                    ViewBag.Count = verses.Count;
                    return View("Index", verses);
                case 2:
                    verses = Service.SearchNT(term);
                    ViewBag.Message = Service.SanitizeInput(term);
                    ViewBag.Count = verses.Count;
                    return View("Index", verses);
                default:
                    return View("Index");
            }
        }

        // default error handling action created by .NET
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
