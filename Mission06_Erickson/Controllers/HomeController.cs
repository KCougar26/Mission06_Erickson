using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Erickson.Models;

namespace Mission06_Erickson.Controllers;

public class HomeController : Controller
{
    private MovieCollectionContext _context;

    public HomeController(MovieCollectionContext temp) // Constructor
    {
        _context = temp;
    }

    public IActionResult Index() => View(); // Home Page 

    public IActionResult GetToKnowJoel() => View(); // About Page 

    [HttpGet]
    public IActionResult AddMovie() => View(); // Form Page 

    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        _context.Movies.Add(response); // Add to DataBase 
        _context.SaveChanges();
        return View("Confirmation"); 
    }
}