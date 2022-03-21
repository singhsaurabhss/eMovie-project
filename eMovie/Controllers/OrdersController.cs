using eMovie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        public OrdersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var movieDetails = _context.Movies
              .Include(c => c.Cinema)
              .Include(p => p.Producer)
              .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
              .FirstOrDefault(n => n.Id == id);
            return View(movieDetails);
            //return View();
        }


        public IActionResult OrderCompleted()
        {
            return View("OrderCompleted");
        }

        //[HttpPost]
        //public IActionResult Index(int id, int tickets)
        //{
        //    int amount = tickets * id;
        //    TempData["Amount"] = amount;
        //    return View(amount);
            
        //}
    }
}
