using System.Diagnostics;
using BlockBuster.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockBuster.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string[] _myColors;
		private readonly string[] _myCities;
		private readonly string[] _myHobbies;


		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _myColors = ["red", "green", "blue"];
			_myCities = ["Tampa", "Boston", "Orlando", "Miami", "Warwick"];
			_myHobbies = ["Gaming", "Car Meets", "Collect Capyara Memorabilia", "Movies", "automotive mechanics"];

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
		public IActionResult Cities()
		{
            string[] cities = { "Tampa", "Boston", "Orlando", "Miami", "Warwick" };
			ViewBag.Cities = cities;
			return View();
		}
		public IActionResult Hobbies()
		{
			string[] hobbies = { "Gaming", "Car Meets", "Collect Capyara Memorabilia", "Movies", "automotive mechanics" };
			ViewBag.Hobbies = hobbies;
			return View();
		}






		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
