using BlockBuster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlockBuster.WebApp.Controllers
{
    public class GenreController : Controller
    {
        // GET: GenreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
			var genre = BasicFunctions.GetGenreById(id);
			return View(genre);

        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
			var genres = new SelectList(BasicFunctions.GetAllGenres()
	        .OrderBy(g => g.GenreDescr)
	        .ToDictionary(g => g.GenreId, g => g.GenreDescr), "Key", "Value");
			ViewBag.GenreId = genres;
			return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genreToCreate)
        {
            try
            {
				BasicFunctions.AddGenre(genreToCreate);
				return RedirectToAction("Genre", "Home");
			}
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
			var genre = AdvancedRepositoryFunctions.GetById<Genre>(id);
			return View(genre);
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genreToEdit)
        {
            try
            {
                BasicFunctions.EditGenre(genreToEdit);
                return RedirectToAction("Genre", "Home");
            }
            catch
            {
                return View();
            }
        }

		// GET: GenreController/Delete/5
		public ActionResult Delete(int id)
        {
			var genre = BasicFunctions.GetGenreById(id);
			return View(genre);
		}

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Genre genre)
        {
			try
			{
				BasicFunctions.DeleteGenre(genre.GenreId);
				return RedirectToAction("Genre", "Home");
			}
			catch
			{
				return View();
			}
		}
    }
}
