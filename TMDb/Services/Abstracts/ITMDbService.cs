using TMDb.Models;

namespace TMDb.Services.Abstracts
{
    public interface ITMDbService
    {
        Task<IList<Movie>> GetMostPopularMoviesAsync();
    }
}