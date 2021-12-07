using Dapper;
using DevBuildMovieDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildMovieDatabase.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            Movie model = new Movie();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Movie model)
        {
            if (ModelState.IsValid)
            {
                using (var connect = new MySqlConnection(Secret.Connection))
                {
                    var sql = "INSERT INTO movies values (@ID, @Title, @Genre, @Year, @Runtime)";
                    connect.Open();
                    connect.Execute(sql, new
                    {
                        ID = model.ID,
                        Title = model.Title,
                        Genre = model.Genre,
                        Year = model.Year,
                        Runtime = model.RunTime
                    });
                    connect.Close();
                    return RedirectToAction("Result", "Movie", model);
                }
            }

            return View(model);
        }

        public IActionResult list(Movie model)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "select * from movies";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Execute(sql, new { });
                connect.Close();
                return View(movies);
            }
            //return View(model);
        }
    }
}
