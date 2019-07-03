using Microsoft.AspNetCore.Mvc;
using Toto.MovieInfo.MovieQueryService.Queries;

namespace Toto.MovieInfo.MovieQueryService
{
    [Route("api/movies")]
    public class MovieOverviewController : Controller
    {
        private readonly IMovieOverviewQueryHandler _movieOverviewQueryHandler;

        public MovieOverviewController(IMovieOverviewQueryHandler movieOverviewQueryHandler)
        {
            _movieOverviewQueryHandler = movieOverviewQueryHandler;
        }

        // GET api/movies
        [HttpGet]
        public IActionResult Get(int skip, int take)
        {
            var query = new MovieOverviewsQuery
            {
                Skip = skip,
                Take = take
            };

            return Ok(_movieOverviewQueryHandler.Handle(query));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
