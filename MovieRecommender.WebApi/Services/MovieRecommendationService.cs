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

        public async Task<IList<Movie>> GetRecommendationsAsync()
        {
            var movies = await tmdbService.GetMostPopularMoviesAsync();

            foreach (var movie in movies)
            {
                var searchKey = $"{movie.Title}";
                var traileryYutubeLink = await youtubeService.GetFirstSearchVideoLinkAsync(searchKey);
                movie.TrailerYoutubeUrl = traileryYutubeLink;
            }

            return movies;
        }

        public bool SendRecommendationViaMail(IList<Movie> movies)
        {
            throw new NotImplementedException();
        }
    }
}
