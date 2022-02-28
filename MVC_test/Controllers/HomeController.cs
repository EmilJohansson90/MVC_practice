using Microsoft.AspNetCore.Mvc;
using MVC_test.Data;
using MVC_test.Models;
using System.Diagnostics;

namespace MVC_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesDBContext _db;

        public HomeController(ILogger<HomeController> logger, MoviesDBContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Movies> orderedList = _db.Movies
                .OrderByDescending(x => x.ReviewScore)
                .Take(5)
                .ToList();

            //TempData["MovieList"] = orderedList;

            return View(orderedList);
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