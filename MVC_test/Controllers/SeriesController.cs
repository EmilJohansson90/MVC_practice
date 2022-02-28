using Microsoft.AspNetCore.Mvc;
using MVC_test.Data;
using MVC_test.Models;

namespace MVC_test.Controllers
{
    public class SeriesController : Controller
    {
        private readonly MoviesDBContext _db;

        public SeriesController(MoviesDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Series> objSeriesList = _db.Series;
            return View(objSeriesList);
        }

        //CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        //CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Series obj)
        {
            if (ModelState.IsValid)
            {
                _db.Series.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //EDIT GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var seriesFromDb = _db.Series.Find(id);

            if (seriesFromDb == null)
            {
                return NotFound();
            }

            return View(seriesFromDb);
        }

        //EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Series obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //DELETE GET
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var seriesFromDb = _db.Series.Find(id);

            if(seriesFromDb == null)
            {
                return NotFound();
            }

            return View(seriesFromDb);
        }

        public IActionResult DeletePOST(int? id)
        {
            var seriesFromDb = _db.Series.Find(id);
            if(seriesFromDb == null)
            {
                return NotFound();
            }
            _db.Series.Remove(seriesFromDb);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
