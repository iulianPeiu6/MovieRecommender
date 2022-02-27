using Microsoft.AspNetCore.Mvc;
using MovieRecommender.WebApi.Services;
using TMDb.Models;

namespace MovieRecommender.WebApi.Controllers.v1
{
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class NotificationController : ControllerBase
    {
        private readonly IMovieRecommendationService movieRecommendationService;

        public NotificationController(IMovieRecommendationService movieRecommendationService)
        {
            this.movieRecommendationService = movieRecommendationService;
        }

        [HttpPost]
        public bool SendRecommendationsViaEmail(IList<Movie> movies)
        {
            return movieRecommendationService.SendRecommendationViaMail(movies);
        }
    }
}
