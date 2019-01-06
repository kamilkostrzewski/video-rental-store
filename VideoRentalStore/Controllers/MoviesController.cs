using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalStore.Models;
using VideoRentalStore.ViewModels;

namespace VideoRentalStore.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new MoviesViewModel
            {
                Movies = new List<Movie>
                {
                    new Movie {Id = 1, Name = "Shrek"},
                    new Movie {Id = 2, Name = "WALL-E"}
                }
            };

            return View(movies);
        }
    }
}