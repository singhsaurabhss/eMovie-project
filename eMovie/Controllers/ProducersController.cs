using eMovie.Data;
using eMovie.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allProducers = _context.Producers.ToList();
            return View(allProducers);
        }

        //Producers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("ProfilePicURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            _context.Add(producer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Producers/Details
        public IActionResult Details(int id)
        {
            var producerDetails = _context.Producers.FirstOrDefault(n => n.Id == id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //Producers/Edit/1
        public IActionResult Edit(int id)
        {
            var producerDetails = _context.Producers.FirstOrDefault(n => n.Id == id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
            // return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,ProfilePicURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            _context.Update(producer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Producers/Delete/1
        public IActionResult Delete(int id)
        {
            var producerDetails = _context.Producers.FirstOrDefault(n => n.Id == id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
            // return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var producerDetails = _context.Producers.FirstOrDefault(n => n.Id == id);
            if (producerDetails == null)
                return View("Not Found");

            //var result = _context.Actors.FirstOrDefault(n => n.Id == id);
            _context.Producers.Remove(producerDetails);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
