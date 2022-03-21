using eMovie.Data;
using eMovie.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allActors = _context.Actors.ToList();
            return View(allActors);
        }

        //Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create([Bind("ProfilePicURL,FullName,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            _context.Add(actor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Actors/Details
        public IActionResult Details(int id)
        {
            var actorDetails = _context.Actors.FirstOrDefault(n => n.Id == id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Actors/Edit/1
        public IActionResult Edit(int id)
        {
            var actorDetails = _context.Actors.FirstOrDefault(n => n.Id == id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
           // return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,ProfilePicURL,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _context.Update(actor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Actors/Delete/1
        public IActionResult Delete(int id)
        {
            var actorDetails = _context.Actors.FirstOrDefault(n => n.Id == id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
            // return View();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var actorDetails = _context.Actors.FirstOrDefault(n => n.Id == id);
            if (actorDetails == null) 
                return View("Not Found");

            var result = _context.Actors.FirstOrDefault(n => n.Id == id);
            _context.Actors.Remove(result);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
