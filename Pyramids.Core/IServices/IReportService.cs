using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Enums;
using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IReportService
    {
        Task<IEnumerable<Job>> GetJobQueryReportData(JobDateTypeEnum? dateType, DateTime? dateFrom, DateTime? dateTo, int? jobTypeId, int? jobSubTypeId, int? jobStatusId, int? jobPriorityId, int? clientId, string? siteId, int? companyId
         );

        Task<IEnumerable<object>> GetTimeSheetReportData( DateTime? dateFrom, DateTime? dateTo, int[]? engineersId);
     
    }
}
