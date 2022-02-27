using SendGrid.Services.Abstracts;
using TMDb.Models;
using TMDb.Services.Abstracts;
using Youtube.Services.Abstracts;

namespace MovieRecommender.WebApi.Services
{
    public class MovieRecommendationService : IMovieRecommendationService
    {
        private readonly ITMDbService tmdbService;
        private readonly IYoutubeService youtubeService;
        private readonly ISendGridService sendgridService;

        public MovieRecommendationService(
            ITMDbService tmdbService,
            IYoutubeService youtubeService,
            ISendGridService sendgridService)
        {
            this.tmdbService = tmdbService;
            this.youtubeService = youtubeService;
            this.sendgridService = sendgridService;
        }

        public IList<Movie> GetRecommendations()
        {
            throw new NotImplementedException();
        }

        public bool SendRecommendationViaMail(IList<Movie> movies)
        {
            throw new NotImplementedException();
        }
    }
}
