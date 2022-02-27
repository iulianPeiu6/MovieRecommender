using TMDb.Models;

namespace MovieRecommender.WebApi.Services
{
    public interface IMovieRecommendationService
    {
        Task<IList<Movie>> GetRecommendationsAsync();
        bool SendRecommendationViaMail(IList<Movie> movies);
    }
}