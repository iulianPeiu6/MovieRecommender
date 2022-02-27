﻿using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TMDb.Models;
using TMDb.Options;
using TMDb.Services.Abstracts;

namespace TMDb.Services
{
    public class TMDbService : TMDbServiceBase, ITMDbService
    {
        public TMDbService(IOptions<TMDbConfiguration> config) : base(config)
        {
        }

        public async Task<IList<Movie>> GetMostPopularMoviesAsync()
        {

            var query = new Dictionary<string, string>()
            {
                ["api_key"] = config.ApiKey,
                ["language"] = "en-US",
                ["sort_by"] = "popularity.desc",
                ["sort_by"] = "popularity.desc",
                ["include_adult"] = "true",
                ["include_video"] = "true"
            };

            var url = QueryHelpers.AddQueryString(config.WebApiEndpoint.DiscoverMovieV3, query);

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            return GetmoviesFromResponse(responseContent);

        }

        private IList<Movie> GetmoviesFromResponse(string responseContent)
        {
            var movies = new List<Movie>();

            var parsedResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

            foreach (var movie in parsedResponse.results)
            {
                movies.Add(new Movie
                {
                    Id = movie.id,
                    Title = movie.title,
                    Overview = movie.overview,
                    ReleaseDate = movie.release_date,
                    PosterUrl = $"{config.WebApiEndpoint.Poster}{movie.poster_path}",
                    Popularity = movie.popularity,
                    Rating = movie.vote_average,
                    NumberOfRatings = movie.vote_count
                });
            }

            return movies;
        }
    }
}
