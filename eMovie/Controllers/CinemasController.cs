using eMovie.Data;
using eMovie.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allCinemas = _context.Cinemas.ToList();
            return View(allCinemas);
        }

        //Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _context.Add(cinema);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Cinemas/Details
        public IActionResult Details(int id)
        {
            var cinemaDetails = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //Cinemas/Edit/1
        public IActionResult Edit(int id)
        {
            var cinemaDetails = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
            // return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            _context.Update(cinema);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Actors/Delete/1
        public IActionResult Delete(int id)
        {
            var cinemaDetails = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
            // return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var cinemaDetails = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            if (cinemaDetails == null)
                return View("Not Found");

            _context.Cinemas.Remove(cinemaDetails);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
