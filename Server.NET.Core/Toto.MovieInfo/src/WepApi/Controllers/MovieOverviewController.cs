using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Toto.MovieInfo.DataAccess;
using Toto.MovieInfo.ModelFactory;
using Toto.MovieInfo.PersistenceModel;
using Toto.MovieInfo.ServiceModel;

namespace Toto.MovieInfo.WepApi.Controllers
{
    [Route("api/movieoverview")]
    public class MovieOverviewController : Controller
    {
        private readonly IQueryHandler<GetMoviesQuery, ICollection<Movie>> _movieQueryHandler;
        private readonly IServiceModelFactory _serviceModelFactory;

        public MovieOverviewController(
            IQueryHandler<GetMoviesQuery, ICollection<Movie>> movieQueryHandler,
            IServiceModelFactory serviceModelFactory)
        {
            _movieQueryHandler = movieQueryHandler;
            _serviceModelFactory = serviceModelFactory;
        }

        [HttpGet()]
        public IActionResult GetMovies()
        {
            var query = new GetMoviesQuery();
            var movies = _movieQueryHandler.Handle(query);

            var movieOverviews = 
                _serviceModelFactory.CreateMovieOverviewCollection(movies);

            return Ok(movieOverviews);
        }
    }
}
