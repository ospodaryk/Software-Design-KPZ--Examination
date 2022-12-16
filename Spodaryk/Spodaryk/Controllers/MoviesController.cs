using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Spodaryk.CustomerData;

namespace Spodaryk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieData movieData;
        public MoviesController(IMovieData data)
        {
            movieData = data;
        }

        [HttpGet]
        public IActionResult GetMoviesList()
        {
            return Ok(movieData.GetMoviesList());
        }
                [HttpPost]
          
                public IActionResult AddMovie(Movie movie)
                {
                    movieData.AddMovie(movie);
                     Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                        HttpContext.Request.Path + '/' + movie.IdMovie, movie);
                     return GetMoviesList();
        }

                [HttpGet]
                [Route("{id}")]
                public IActionResult GetMovie(int id)
                {
                    var movie = movieData.GetMovie(id);
                    if (movie != null)
                    {
                        return Ok(movie);
                    }
                    return NotFound($"Movie with id {id} was not found");
                }

                [HttpDelete]
                [Route("{id}")]
                public IActionResult DeleteMovie(int id)
                {
                    var movie = movieData.GetMovie(id);
                    if (movie != null)
                    {
                        movieData.DeleteMovie(id);
                        return GetMoviesList();
            }
                    return NotFound($"Cannot find the Movie with Id: {id}");
        }

                [HttpPut]
                public IActionResult UpdateMovie(Movie movie)
                {
                    var m = movieData.GetMovie(movie.IdMovie);
                    if (m != null)
                    {
                return Ok(movieData.UpdateMovie(movie));
              }
                    return NotFound($"Cannot find the Movie with Id: {movie.IdMovie}");
                }
            }
    }


