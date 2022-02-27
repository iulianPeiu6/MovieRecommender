using Microsoft.Extensions.Options;
using MovieRecommender.Application.Interfaces;
using MovieRecommender.Domain.Entities;
using System.Diagnostics;
using TMDb.Options;

namespace TMDb.Services.Abstracts
{
    public abstract class TMDbServiceBase
    {
        protected readonly TMDbConfiguration config;
        protected readonly HttpClient client;
        private readonly IRequestLogRepository repository;

        public TMDbServiceBase(IOptions<TMDbConfiguration> config, IRequestLogRepository repository)
        {
            this.config = config.Value;
            this.repository = repository;
            client = new HttpClient();
        }

        protected async Task<string> MakeRequest(HttpRequestMessage request)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            var response = await client.SendAsync(request);
            watch.Stop();

            var responseContent = await response.Content.ReadAsStringAsync();

            var requestLog = new RequestLog
            {
                Endpoint = request.RequestUri.ToString(),
                HttpMethod = request.Method.Method,
                Provider = "TMDb",
                RequestContent = request.Content?.ToString(),
                StatusCode = response.StatusCode.ToString(),
                ResponseContent = responseContent,
                Latency = watch.ElapsedMilliseconds
            };
            repository.Add(requestLog);

            return responseContent;
        }
    }
}