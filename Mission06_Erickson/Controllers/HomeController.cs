using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
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

    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title)
            .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult AddMovie() // Form Page 
    {
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        return View("AddMovie", new Movie());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        if (ModelState.IsValid) // This checks the [Required] and [Range] rules
        {
            _context.Movies.Add(response);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        ViewBag.Categories = _context.Categories.ToList();
        return View(response);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        // Pull the record to show the user what they are deleting
        var movie = _context.Movies.FirstOrDefault(x => x.MovieId == id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories.ToList();
        return View("AddMovie", movie);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        ViewBag.Categories = _context.Categories.ToList();
        return View("AddMovie", movie);
    }
}