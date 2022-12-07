using FA.Services.Models;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public MovieController()
        {
        }

        [HttpGet("getAllMovies")]
        public List<MovieInfo> getAllMovies()
        {

            return new List<MovieInfo>();
            //try
            //{
            //    return userService.getShelter(shelterId);
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex);
            //    throw new Exception("", ex);
            //}
        }

        [HttpGet("getWatchedMoviesForUser")]
        public List<MovieInfo> getWatchedMoviesForUser(int userId)
        {
            return new List<MovieInfo>();
        }
        [HttpPatch("addMovieAsWatched")]
        public void addMovieAsWatched(int userId,int movieId)
        {

        }
        [HttpDelete("removeMovieFromWatched")]
        public void removeMovieFromWatched(int userId, int movieId)
        {

        }
        [HttpGet("getMovieSugestions")]
        public List<MovieInfo> getMovieSugestions(int userId, string mood)
        {
            return new List<MovieInfo>();
        }
    }
}
