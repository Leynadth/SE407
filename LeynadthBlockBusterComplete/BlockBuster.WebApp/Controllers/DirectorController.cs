using BlockBuster.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlockBuster.WebApp.Controllers
{
    public class DirectorController : Controller
    {
        // GET: DirectorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DirectorController/Details/5
        public ActionResult Details(int id)
        {
			var director = BasicFunctions.GetDirectorById(id);
			return View(director);
		}

        // GET: DirectorController/Create
        public ActionResult Create()
        {
			var directors = new SelectList(BasicFunctions.GetAllDirectors()
				.OrderBy(d => d.LastName)
				.ToDictionary(d => d.DirectorId, d => d.LastName + ", " + d.FirstName), "Key", "Value");
			ViewBag.DirectorId = directors;

			return View();
		}

        // POST: DirectorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create(Director directorToCreate)
		{
			try
			{
				BasicFunctions.AddDirector(directorToCreate);
				return RedirectToAction("Director", "Home");
			}
			catch
			{
				return View();
			}
		}

		// GET: DirectorController/Edit/5
		public ActionResult Edit(int id)
        {
			var director = AdvancedRepositoryFunctions.GetById<Director>(id);
			return View(director);
		}

        // POST: DirectorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Edit(Director directorToEdit)
		{
			try
			{
				BasicFunctions.EditDirector(directorToEdit);
				return RedirectToAction("Director", "Home");
			}
			catch
			{
				return View();
			}
		}

		// GET: DirectorController/Delete/5
		public ActionResult Delete(int id)
        {
			var director = BasicFunctions.GetDirectorById(id);
			return View(director);
		}

        // POST: DirectorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Director director)
        {
			try
			{
				BasicFunctions.DeleteDirector(director.DirectorId);
				return RedirectToAction("Director", "Home");
			}
			catch
			{
				return View();
			}
		}
    }
}
