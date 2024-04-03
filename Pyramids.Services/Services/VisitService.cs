using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Enums;
using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;
using Contract = Pyramids.Core.Models.Contract;

namespace Pyramids.Service.Services
{

    public class VisitService : Service<Visit>, IVisitService
    {
        private readonly IReminderService _reminderService;
        private readonly IUserService _userService;
        private readonly IJobService _jobService;

        public VisitService(IUnitOfWork unitOfWork, IGenericRepository<Visit> repository, IReminderService reminderService, IJobService jobService, IUserService userService) : base(unitOfWork, repository)
        {
            _reminderService = reminderService;
            _jobService = jobService;
            _userService = userService;
        }

        public async Task<IEnumerable<Visit>> GetAllAsync(bool isActive, int companyId)
            => await _unitOfWork.VisitRepository.GetAllAsync(isActive, companyId);

        public async Task<bool> GenerateVisits(Contract contract)
        {
            return await _unitOfWork.VisitRepository.GenerateVisits(contract);
        }

        public async Task<int> GenerateJobVisitsAsync(List<int> visitsId, User currentUser)
        {
            try
            {
                var res = 0;
                var selectedVisits = await _unitOfWork.VisitRepository.Where(x => visitsId.Contains(x.Id), "Contract.Visits,Reminders");

                foreach (var visit in selectedVisits)
                {

                    if (visit.IsGenerated == false || visit.IsGenerated == null)
                    {
                        var logJob = new Job()
                        {
                            ClientId = visit?.Contract?.ClientId,
                            JobDate = visit?.VisitDate,
                            JobTypeId = visit?.Contract?.JobTypeId,
                            JobSubTypeId = visit?.Contract?.JobSubTypeId,
                            EngineerId = visit?.Contract?.DefaultEngineerId,
                            Description = visit?.Contract?.Description,
                            EstimatedDuration = visit?.Contract?.EstimatedDurationMinutes ?? 120,
                            PriorityId = (int?)JobPriorityEnum.MEDIUM,
                            CompanyId = currentUser.CompanyId,
                            CreatedByUserId = currentUser.Id,
                            JobStatusId = (int?)JobStatusEnum.OPEN,

                        };
                        var createdJob = await _jobService.LogJobFromVisitAsync(currentUser, logJob, JobActionSourceEnum.PPM);

                        if (createdJob != null)
                        {
                            //to do: add parts and attachments to  JobFile(from contract files) and JobParts(from contract parts)

                            visit.JobId = createdJob.Id;
                            visit.IsGenerated = true;
                            visit.GeneratedDate = DateTime.Now;
                            visit.GeneratedByUserId = currentUser.Id;

                            var nextVisit = visit.Contract.Visits.Where(x => x.IsGenerated == false || x.IsGenerated == null && x.VisitDate > visit.VisitDate).FirstOrDefault();
                            visit.Contract.NextVisitDate = nextVisit?.VisitDate;

                            var visitReminders = visit.Reminders.Where(x => x.ReminderType == "GEN").FirstOrDefault();
                            if (visitReminders != null)
                            {
                                _unitOfWork.ReminderSeenRepository.RemoveWhere(x => x.ReminderId == visitReminders.Id);
                                _unitOfWork.ReminderRepository.Remove(visitReminders);
                            }


                            if (visit.Contract.DefaultEngineerId == null)
                            {
                                await _reminderService.GenerateUnscheduledReminder(createdJob, visit);
                            }

                            else
                            {
                                //to do: check if the engineer has a job for the same date and time and according create a reminder
                                //var jobs = _unitOfWork.JobRepository.FindAllEngineersAssignedJobsForDate(currentUser, visit.Contract.DefaultEngineerId.Value, null, visit.VisitDate.Date, visit.Contract.EstimatedDurationMinutes ?? 120);


                                bool hasConflict = false;
                                //if (jobs.Any())
                                if (hasConflict)
                                {
                                    await _reminderService.GenerateConflictReminder(createdJob, visit);
                                }
                            }

                        }


                    }
                }
                await _unitOfWork.CommitAsync();
                return res;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }


        // generate visit automatically
        public async Task GenerateJobVisitsForTodayAsync()
        {
            var currentUser = _unitOfWork.UserRepository.GetById(2);
            var visitDate = DateTime.Now.AddDays(-1).Date;
            var visitToDate = DateTime.Now.AddDays(2).Date;

            var visitsId = _unitOfWork.VisitRepository.Where(x => x.IsGenerated == false
                                                           && visitDate <= x.VisitDate && x.VisitDate < visitToDate
                                                           && x.Contract.IsActive).Result.Select(a => a.Id).ToList();

            await GenerateJobVisitsAsync(visitsId, currentUser!);

            //todo:(sample provided below) first group visits then find contract.DefaultEngineer, then check for UserAdmins if exists.

            //var visitsToBeGenerated = _unitOfWork.VisitRepository.Where(x => x.IsGenerated == false
            //                    && visitDate <= x.VisitDate && x.VisitDate < visitToDate
            //                    && x.Contract.IsActive).Result.GroupBy(x => new {x.Contract.ClientId,x.Contract.Client.CompanyId}).ToList();


            //if (visitsToBeGenerated != null)
            //{
            //    foreach (var grp in visitsToBeGenerated)
            //    {
            //        try
            //        {
            //            var user = grp.Select(x => x.Contract.DefaultEngineer).First();

            //var userExt = usr.UserAdmins.Where(x => x.CompanyID == grp.Key.CompanyID).FirstOrDefault();
            //if (usrExt == null)
            //{
            //    usrExt = ctx.UserAdmins.FindSingle(x => x.CompanyID == grp.Key.CompanyID);
            //}
            //var userCurrent = new Pyramid.Domain.Entities.Abstract.UserInfo()
            //{
            //    Id = usr.Id,
            //    ClientId = grp.Key.ClientId,
            //    CompanyId = grp.Key.CompanyId,
            //    InterfaceType = UserInterfaceType.Admin,
            //    UserExtId = userExt.UserAdminId,
            //    Name = "PPM Integration",
            //    Domain = user.LastDomainName
            //};
            //ppmService.GenerateJobVisits(grp.Select(x => x.VisitId).ToList(), userCurrent);

            //        }
            //        catch (Exception ex)
            //        {
            //          
            //        }
            //    }
            //}
           

           

            
        }
    }
}
