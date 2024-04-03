using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IJobSessionService _jobSessionService;


        public ReportService(IReportRepository reportRepository, IJobSessionService jobSessionService)
        {

            _reportRepository = reportRepository;
            _jobSessionService = jobSessionService;
        }
        public async Task<IEnumerable<Job>> GetJobQueryReportData(JobDateTypeEnum? dateType, DateTime? dateFrom, DateTime? dateTo, int? jobTypeId, int? jobSubTypeId, int? jobStatusId, int? jobPriorityId, int? clientId, string? siteId, int? companyId)
        {
            return await _reportRepository.GetJobQueryReportData(dateType, dateFrom, dateTo, jobTypeId, jobSubTypeId, jobStatusId, jobPriorityId, clientId, siteId, companyId);
        }


        #region TimeSheetStart
        public Task<IEnumerable<object>> GetTimeSheetReportData(DateTime? dateFrom, DateTime? dateTo, int[]? engineersId)
        {
            List<JobSession> jobSessions = findJobSession(dateFrom, dateTo, engineersId).ToList();

            if (jobSessions != null)
            {
                var engineersTotalTime = jobSessions.Select(s => new

                {
                    EngineerAssignedId = s.EngineerAssignedId,
                    EngineerName = s.EngineerAssigned.FirstName + " " + s.EngineerAssigned.LastName,
                    //Todo: implementation of CalculateTotalTime/CalculateTotalTimeInMinutes/CalculateCost according to company settings.

                }).GroupBy(s => new { s.EngineerAssignedId, s.EngineerName });


                return Task.FromResult(engineersTotalTime.AsEnumerable<object>());
            }
            return Task.FromResult(new List<object>().AsEnumerable<object>());


        }
        #endregion TimeSheetEnd



        private IEnumerable<JobSession> findJobSession(DateTime? dateFrom, DateTime? dateTo, int[]? engineersId)
        {
            bool areEngineersSelected = engineersId != null && engineersId.Length > 0;
            var jobSessions = _jobSessionService.Where(js => js.EngineerAssignedId.HasValue
                    && areEngineersSelected || engineersId.Any(a => a == js.EngineerAssignedId.Value)

                    && (js.SessionStatusId == (int)JobSessionStatusEnum.RESOLVED || js.SessionStatusId == (int)JobSessionStatusEnum.FINISHED
                          || js.SessionStatusId == (int)JobSessionStatusEnum.REMOTEFINISHED)
                    &&
                       (js.TravelStart.HasValue && js.TravelStart >= dateFrom && js.TravelStart <= dateTo
                        || js.TravelEnd.HasValue && js.TravelEnd >= dateFrom && js.TravelEnd <= dateTo
                        || js.WorkStart.HasValue && js.WorkStart >= dateFrom && js.WorkStart <= dateTo
                        || js.WorkEnd.HasValue && js.WorkEnd >= dateFrom && js.WorkEnd <= dateTo

                    )).Result.OrderBy(a => a.EngineerAssigned.FirstName).ThenBy(a => a.EngineerAssigned.LastName);

            return jobSessions;
        }

    }
}
