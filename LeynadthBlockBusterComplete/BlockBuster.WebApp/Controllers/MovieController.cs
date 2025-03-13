using BlockBuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlockBuster.WebApp.Controllers
{
    public class MovieController : Controller
    {
        // GET: MovieController
        public ActionResult Index()
        {
            return View();
        }



        // GET: MovieController/Details/5
        public ActionResult MovieDetails(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movie);
        }



        // GET: MovieController/Create
        public ActionResult Create()
        {
			var genres = new SelectList(BasicFunctions.GetAllGenres()
				.OrderBy(g => g.GenreDescr)
				.ToDictionary(g => g.GenreId, g => g.GenreDescr), "Key", "Value");
			ViewBag.GenreId = genres;

			var directors = new SelectList(BasicFunctions.GetAllDirectors()
				.OrderBy(d => d.LastName)
				.ToDictionary(d => d.DirectorId, d => d.LastName + ", " + d.FirstName), "Key", "Value");
			ViewBag.DirectorId = directors;

			return View();

		}



		// POST: MovieController/Create
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movieToCreate)
        {
            try
            {
                BasicFunctions.AddMovie(movieToCreate);
                return RedirectToAction("Movies","Home");
            }
            catch
            {
                return View();
            }
        }



        // GET: MovieController/Edit/5
        // (Navigates to Edit Page)
        public ActionResult EditMovie(int id)
        {
            var movie = AdvancedRepositoryFunctions.GetById<Movie>(id);

            ViewBag.GenreId =
                new SelectList
                (
                    AdvancedRepositoryFunctions.GetAll<Genre>(),
                    "GenreId",
                    "GenreDescr"
                );
                
            ViewBag.DirectorId =
                   new SelectList
                    (
                        AdvancedRepositoryFunctions.GetAll<Director>(),
                        "DirectorId",
                        "FullName"
                    );

            return View(movie);
        }


        // POST: MovieController/Edit/5
        // (Updates the Movie)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMovie(int id, IFormCollection collection)
        {
            try
            {
                var targetDirector =
                    AdvancedRepositoryFunctions
                        .GetById<Director>
                        (
                            int.Parse(collection["DirectorId"])
                        );

                var targetGenre =
                    AdvancedRepositoryFunctions
                        .GetById<Genre>
                        (
                            int.Parse(collection["GenreId"])
                        );

                var propsToUpdate = new List<(string propName, object? propValue)>
                {
                    (nameof(Movie.Title), (string)collection[nameof(Movie.Title)]),
                    (nameof(Movie.ReleaseYear), int.Parse(collection[nameof(Movie.ReleaseYear)])),
                    (nameof(Movie.Director), targetDirector),
                    (nameof(Movie.Genre), targetGenre)
                };
                        

                AdvancedRepositoryFunctions
                    .Update<Movie>
                    (
                        id,
                        propsToUpdate
                    );

                return RedirectToAction(nameof(MovieDetails));
            }
            catch
            {
                return View();
            }
        }


        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            var movie = BasicFunctions.GetMovieWithDetailsById(id);
            return View(movie);
        }


        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Movie movie)
        {
			try
			{
				BasicFunctions.DeleteMovie(movie.MovieId);
				return RedirectToAction("Movie", "Home");
			}
			catch
			{
				return View();
			}
		}
    }
}
