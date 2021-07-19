using Activity2a.Models;
using Activity2a.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2a.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            /*List<MovieModel> MovieList = new List<MovieModel>();
            MovieList.Add(new MovieModel { Id = 1, Genre = "Horror", MovieName = "A Quiet Place", Rating = 8.9m });
            MovieList.Add(new MovieModel { Id = 2, Genre = "Horror", MovieName = "A Quiet Place 2", Rating = 7.9m });*/
            HardCodedMovieRepository hardCodedMovieRepository = new HardCodedMovieRepository();
            return View(hardCodedMovieRepository.GetAllProducts());
        }
    }
}
