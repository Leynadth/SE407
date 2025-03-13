using LeynadthBookstore;
using LeynadthBookstore.Models;
using LeynadthBookstoreWebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeynadthBookstoreWebApp.Controllers
{
    public class GenresController : Controller
    {
        // GET: GenresController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GenresController/Details/5
        public ActionResult Details(int id)
        {
			var genre = BasicFunctions.GetGenreById(id);
			return View(genre);
        }

        // GET: GenresController/Create
        public ActionResult Create()
        {
			ViewBag.GenreId = DropDownFormatter.FormatGenre();

			return View();
        }

        // POST: GenresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genreToCreate)
        {
			try
			{
				BasicFunctions.AddGenre(genreToCreate);
				return RedirectToAction("Genres", "Home");
			}
			catch
			{
				return View();
			}
		}

        // GET: GenresController/Edit/5
        public ActionResult Edit(int id)
        {
			var genre = BasicFunctions.GetGenreById(id);
			ViewBag.GenreId = DropDownFormatter.FormatGenre();
			return View(genre);
        }

        // POST: GenresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genreToEdit)
        {
			try
			{
				BasicFunctions.EditGenre(genreToEdit);
				return RedirectToAction("Books", "Home");
			}
			catch
			{
				return View();
			}
		}

        // GET: GenresController/Delete/5
        public ActionResult Delete(int id)
        {
			var genre = BasicFunctions.GetGenreById(id);
			return View(genre);
		}

        // POST: GenresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Genre genre)
        {
            try
			{
				BasicFunctions.DeleteGenre(genre.GenreId);
				return RedirectToAction("Genres", "Home");
			}
			catch
            {
                return View();
            }
        }
    }
}
