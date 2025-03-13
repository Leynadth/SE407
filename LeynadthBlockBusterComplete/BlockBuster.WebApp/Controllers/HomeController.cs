using System.Diagnostics;
using BlockBuster.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string[] _myColors;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _myColors = ["red", "green", "blue"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Colors()
        {
            ViewBag.MyColors = _myColors;
            return View();
        }


        public IActionResult Movie()
        {
            var movies = BasicFunctions.GetAllMoviesWithDetails();
            return View(movies);
        }

		public IActionResult Director()
		{
			var directors = BasicFunctions.GetAllDirectors();
			return View(directors);
		}

		public IActionResult Genre()
		{
			var genres = BasicFunctions.GetAllGenres();
			return View(genres);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
