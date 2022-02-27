using TMDb.Models;

namespace MovieRecommender.WebApi.Services
{
    public interface IMovieRecommendationService
    {
        IList<Movie> GetRecommendations();
        bool SendRecommendationViaMail(IList<Movie> movies);
    }
}