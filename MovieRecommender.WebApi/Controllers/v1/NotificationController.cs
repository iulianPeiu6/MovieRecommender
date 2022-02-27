﻿using Microsoft.AspNetCore.Mvc;
using MovieRecommender.Application.Interfaces;
using MovieRecommender.Domain.Entities;

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
        public async Task<bool> SendRecommendationsViaEmailAsync(IList<Movie> movies, string email)
        {
            return await movieRecommendationService.SendRecommendationViaMailAsync(movies, email);
        }
    }
}
