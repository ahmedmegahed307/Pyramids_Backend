using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Enums;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Shared.Extensions;

namespace Pyramids.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }
        //JobQuery
        public async Task<IEnumerable<Job>> GetJobQueryReportData(JobDateTypeEnum? dateType, DateTime? dateFrom, DateTime? dateTo, int? jobTypeId, int? jobSubTypeId, int? jobStatusId, int? jobPriorityId, int? clientId, string? siteId, int? companyId)
        {

            List<int> sites = string.IsNullOrEmpty(siteId) ? new List<int>() : siteId.Split(';').Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList();

            //Date type filters
            bool ignoreDate = dateType == JobDateTypeEnum.NONE;
            bool filterByLoggedDate = dateType == JobDateTypeEnum.LOGGED;
            bool filterByAssignedDate = dateType == JobDateTypeEnum.ASSIGNED;
            bool filterByClosedDate = dateType == JobDateTypeEnum.CLOSED;
            bool filterByScheduleDate = dateType == JobDateTypeEnum.SCHEDULED;
            bool filterByResolvedDate = dateType == JobDateTypeEnum.RESOLVED;
            bool filterByCancelledDate = dateType == JobDateTypeEnum.CANCELLED;

            //Job Actions Filters
            string assignedActionCode = JobActionTypeEnum.Assigned.ToDescriptionString();
            string resolvedOnMobileActionCode = JobActionTypeEnum.ResolvedOnMobile.ToDescriptionString();
            string resolvedOnAdminActionCode = JobActionTypeEnum.ResolvedOnAdmin.ToDescriptionString();
            string closedOnAdminActionCode = JobActionTypeEnum.ClosedOnAdmin.ToDescriptionString();
            string cancelledActionCode = JobActionTypeEnum.Cancelled.ToDescriptionString();
            string closedRemotelyActionCode = JobActionTypeEnum.CloseRemote.ToDescriptionString();

            var query = _context.Jobs
          .Include(j => j.Priority)
          .Include(j => j.Engineer)
          .Include(j => j.JobStatus)
          .Include(j => j.JobType)
          .Include(j => j.JobSubType)
          .Include(j => j.Site)
          .Include(j => j.Client)
          .AsQueryable();

            query = query.Where(j =>
                            (ignoreDate || (!ignoreDate
                                                      //by logged date
                                                      && (!filterByLoggedDate || (filterByLoggedDate
                                                                                  && (!dateFrom.HasValue || j.CreatedAt >= dateFrom.Value)
                                                                                  && (!dateTo.HasValue || j.CreatedAt <= dateTo.Value)))
                                                      //by assigned date
                                                      && (!filterByAssignedDate || (filterByAssignedDate
                                                                                  && j.JobActions.OrderByDescending(a => a.Id)
                                                                                      .Where(a => a.JobActionType.Code == assignedActionCode &&
                                                                                      (!dateFrom.HasValue || a.ActionDate >= dateFrom.Value) &&
                                                                                      (!dateTo.HasValue || a.ActionDate <= dateTo.Value)).Any()))
                                                      //By scheduled Date
                                                      && (!filterByScheduleDate || (filterByScheduleDate
                                                                                  && (!dateFrom.HasValue || j.JobDate >= dateFrom.Value)
                                                                                  && (!dateTo.HasValue || j.JobDate <= dateTo.Value)))
                                                      //by cancelled date
                                                      && (!filterByCancelledDate || (filterByCancelledDate
                                                                                   && j.JobActions.OrderByDescending(a => a.Id)
                                                                                      .Where(a => a.JobActionType.Code == cancelledActionCode &&
                                                                                      (!dateFrom.HasValue || a.ActionDate >= dateFrom.Value) &&
                                                                                      (!dateTo.HasValue || a.ActionDate <= dateTo.Value)).Any()))
                                                      //by closed date
                                                      && (!filterByClosedDate || (filterByClosedDate
                                                                                  && j.JobActions.OrderByDescending(a => a.Id)
                                                                                      .Where(a => (a.JobActionType.Code == closedOnAdminActionCode) &&
                                                                                      (!dateFrom.HasValue || a.ActionDate >= dateFrom.Value) &&
                                                                                      (!dateTo.HasValue || a.ActionDate <= dateTo.Value)).Any()))
                                                      //by Resolved date
                                                      && (!filterByResolvedDate || (filterByResolvedDate
                                                                                  && j.JobActions.OrderByDescending(a => a.Id)
                                                                                              .Where(a => (a.JobActionType.Code == resolvedOnMobileActionCode
                                                                                               || a.JobActionType.Code == resolvedOnAdminActionCode
                                                                                               || a.JobActionType.Code == closedRemotelyActionCode) &&
                                                                                              (!dateFrom.HasValue || a.ActionDate >= dateFrom.Value) &&
                                                                      (!dateTo.HasValue || a.ActionDate <= dateTo.Value)).Any())))

                              && (j.CompanyId == companyId)
                              && (!dateFrom.HasValue || j.JobDate >= dateFrom)
                              && (!dateTo.HasValue || j.JobDate <= dateTo)
                              && (sites.Count == 0 || (sites.Count > 0 && sites.Contains(j.SiteId ?? 0)))
                              && (!jobTypeId.HasValue || j.JobTypeId == jobTypeId)
                              && (!jobSubTypeId.HasValue || j.JobSubTypeId == jobSubTypeId)
                              && (!jobStatusId.HasValue || j.JobStatusId == jobStatusId)
                              && (!jobPriorityId.HasValue || j.PriorityId == jobPriorityId)
                              && (!clientId.HasValue || j.ClientId == clientId)));

            return await query.ToListAsync();
        }

    }
}
