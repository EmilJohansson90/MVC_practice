using Microsoft.AspNetCore.Mvc;
using MVC_test.Data;
using MVC_test.Models;

namespace MVC_test.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesDBContext _db;

        public MoviesController(MoviesDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Movies> objMovieList = _db.Movies;
            return View(objMovieList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movies obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie has been added";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movieFromDb = _db.Movies.Find(id);

            if (movieFromDb == null)
            {
                return NotFound();
            }

            return View(movieFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movies obj)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Movie has been updated";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var movieFromDb = _db.Movies.Find(id);

            if (movieFromDb == null)
            {
                return NotFound();
            }

            return View(movieFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Movies.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Movies.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Movie has beed deleted";
            return RedirectToAction("Index");

            return View(obj);
        }
    }
}
