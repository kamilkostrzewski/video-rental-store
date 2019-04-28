using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VideoRentalStore.Models;
using VideoRentalStore.ViewModel;

namespace VideoRentalStore.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Genre).ToList();
            return View(movies);
        }

         public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View("New", viewModel);
        }

         [HttpPost]
         public ActionResult Save(Movie movie)
         {
             if (movie.Id == 0)
             {
                 _context.Movies.Add(movie);
             }
             else
             {
                 var customerInDb = _context.Movies
                     .Single(c => c.Id == movie.Id);
                 customerInDb.Name = movie.Name;
                 customerInDb.ReleaseDate = movie.ReleaseDate;
                 customerInDb.GenreId = movie.GenreId;
                 customerInDb.NumberInStock = movie.NumberInStock;
             }
             _context.SaveChanges();

             return RedirectToAction("Index", "Movies");
         }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movies == null)
            {
                return HttpNotFound();
            }

            return View(movies);
        }
    }
}