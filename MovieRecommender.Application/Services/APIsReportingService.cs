using MovieRecommender.Application.Interfaces;
using MovieRecommender.Domain.Entities;

namespace MovieRecommender.Application.Services
{
    public class APIsReportingService : IAPIsReportingService
    {
        private readonly IRequestLogRepository requestLogs;

        public APIsReportingService(IRequestLogRepository requestLogs)
        {
            this.requestLogs = requestLogs;
        }
        public Report GenerateReport()
        {
            var report = new Report
            {
                APIRequests = requestLogs.GetAll()
            };

            return report;
        }
    }
}
