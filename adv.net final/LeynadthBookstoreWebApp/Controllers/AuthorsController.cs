using Humanizer.Localisation;
using LeynadthBookstore;
using LeynadthBookstore.Models;
using LeynadthBookstoreWebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeynadthBookstoreWebApp.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: AuthorsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AuthorsController/Details/5
        public ActionResult Details(int id)
        {
			var author = BasicFunctions.GetAuthorById(id);
			return View(author);
		}

        // GET: AuthorsController/Create
        public ActionResult Create()
        {
			ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
			return View();
		}

        // POST: AuthorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Author authorToCreate)
		{
			try
			{
				BasicFunctions.AddAuthor(authorToCreate);
				return RedirectToAction("Authors", "Home");
			}
			catch
			{
				return View();
			}
		}

		// GET: AuthorsController/Edit/5
		public ActionResult Edit(int id)
        {
			var author = BasicFunctions.GetAuthorById(id);
			ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
			return View(author);
		}

        // POST: AuthorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author authorToEdit)
        {
            try
            {
				BasicFunctions.EditAuthor(authorToEdit);
				return RedirectToAction("Books", "Home");
			}
            catch
            {
                return View();
            }
        }

        // GET: AuthorsController/Delete/5
        public ActionResult Delete(int id)
        {
			var author = BasicFunctions.GetAuthorById(id);
			return View(author);
		}

        // POST: AuthorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author author)
        {
			try
            {
				BasicFunctions.DeleteAuthor(author.AuthorId);
				return RedirectToAction("Authors", "Home");
			}
            catch
            {
                return View();
            }
        }
    }
}
