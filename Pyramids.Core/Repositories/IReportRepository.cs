using Pyramids.Core.Enums;
using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<Job>> GetJobQueryReportData(JobDateTypeEnum? dateType, DateTime? dateFrom, DateTime? dateTo, int? jobTypeId, int? jobSubTypeId, int? jobStatusId, int? jobPriorityId, int? clientId, string? siteId, int? companyId);

    }
}
