using Amphibian.Oep.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Repositories
{
    public interface IApiLogRepository
    {
        Task InsertApiLog(ApiLog log);
        Task<IEnumerable<ApiLogDto>> SearchApiLogs(DateTime? from, DateTime? to, int? userId, string route);
        Task UpdateApiLog(ApiLog log);
        Task<IEnumerable<RouteMetrics>> GetRouteMetrics(DateTime? from, DateTime? to, int? userId, string route);
    }
}