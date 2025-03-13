using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LeynadthBookstoreWebApp.Models;
using System.Net;
using LeynadthBookstore;

namespace LeynadthBookstoreWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

	public IActionResult Books()
	{
        var books = BasicFunctions.GetAllBooksFull();
		return View(books);
	}

	public IActionResult Authors()
	{
		var author = BasicFunctions.GetAllAuthors();
		return View(author);
	}

	public IActionResult Genres()
	{
		var genre = BasicFunctions.GetAllGenres();
		return View(genre);
	}



	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
