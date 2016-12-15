using Microsoft.AspNetCore.Mvc;

namespace Toto.MovieInfo.WepApi.Controllers
{
    [Route("api/movies")]
    public class MoviesController : Controller
    {
        [HttpGet()]
        public IActionResult GetMovies()
        {
            return Ok("Done!");
        }
    }
}
