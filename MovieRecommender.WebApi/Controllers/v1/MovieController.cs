using Microsoft.AspNetCore.Mvc;
using MovieRecommender.WebApi.Services;
using TMDb.Models;

namespace MovieRecommender.WebApi.Controllers.v1
{
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRecommendationService movieRecommendationService;

        public MovieController(IMovieRecommendationService movieRecommendationService)
        {
            this.movieRecommendationService = movieRecommendationService;
        }

        [HttpGet]
        public IList<Movie> GetRecommendations()
        {
            return movieRecommendationService.GetRecommendations();
        }
    }
}
