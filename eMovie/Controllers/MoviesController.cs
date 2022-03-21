using eMovie.Data;
using eMovie.Models;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allMovies = _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToList();
            return View(allMovies);
        }

        //Filter search
        public IActionResult Filter(string searchString)
        {
            var allMovies = _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToList();
            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }
            
            return View("Index",allMovies);
        }

        //Movies/Details
        public IActionResult Details(int id)
        {
            //var actorDetails = _context.Actors.FirstOrDefault(n => n.Id == id);
            //if (actorDetails == null) return View("NotFound");
            var movieDetails = _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefault(n => n.Id == id);
            return View(movieDetails);
        }

        //Movies/Create
        public IActionResult Create()
        {
            var movieDropdownsData = new NewMovieDropdownsVM()
            {
                Actors = _context.Actors.OrderBy(n => n.FullName).ToList(),
                Cinemas = _context.Cinemas.OrderBy(n => n.Name).ToList(),
                Producers = _context.Producers.OrderBy(n => n.FullName).ToList()
            };

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = new NewMovieDropdownsVM()
                {
                    Actors = _context.Actors.OrderBy(n => n.FullName).ToList(),
                    Cinemas = _context.Cinemas.OrderBy(n => n.Name).ToList(),
                    Producers = _context.Producers.OrderBy(n => n.FullName).ToList()
                };

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }
            var newMovie = new Movie()
            {
                Name = movie.Name,
                Description = movie.Description,
                Price = movie.Price,
                ImageURL = movie.ImageURL,
                CinemaId = movie.CinemaId,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MovieCategory = movie.MovieCategory,
                ProducerId = movie.ProducerId
            };

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            //Add actor movies
            foreach (var actorId in movie.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                _context.Actors_Movies.Add(newActorMovie);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Movies/Edit
        public IActionResult Edit(int id)
        {
            var movieDetails = _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefault(n => n.Id == id);
            if (movieDetails == null) return View("NotFound");
            //return View(movieDetails);

            var response = new NewMovieVM()
            {
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                CinemaId = movieDetails.CinemaId,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieCategory = movieDetails.MovieCategory,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var movieDropdownsData = new NewMovieDropdownsVM()
            {
                Actors = _context.Actors.OrderBy(n => n.FullName).ToList(),
                Cinemas = _context.Cinemas.OrderBy(n => n.Name).ToList(),
                Producers = _context.Producers.OrderBy(n => n.FullName).ToList()
            };

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public IActionResult Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = new NewMovieDropdownsVM()
                {
                    Actors = _context.Actors.OrderBy(n => n.FullName).ToList(),
                    Cinemas = _context.Cinemas.OrderBy(n => n.Name).ToList(),
                    Producers = _context.Producers.OrderBy(n => n.FullName).ToList()
                };

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            var dbMovie = _context.Movies.FirstOrDefault(n => n.Id == movie.Id);
            if (dbMovie != null)
            {

                dbMovie.Name = movie.Name;
                dbMovie.Description = movie.Description;
                dbMovie.Price = movie.Price;
                dbMovie.ImageURL = movie.ImageURL;
                dbMovie.CinemaId = movie.CinemaId;
                dbMovie.StartDate = movie.StartDate;
                dbMovie.EndDate = movie.EndDate;
                dbMovie.MovieCategory = movie.MovieCategory;
                dbMovie.ProducerId = movie.ProducerId;

                _context.SaveChanges();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == movie.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            _context.SaveChanges();

            //Add actor movies
            foreach (var actorId in movie.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                _context.Actors_Movies.Add(newActorMovie);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult BuyItem(int id)
        {
            var movieDetails = _context.Movies
               .Include(c => c.Cinema)
               .Include(p => p.Producer)
               .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
               .FirstOrDefault(n => n.Id == id);
            return View(movieDetails);
            
        }
    }
}
