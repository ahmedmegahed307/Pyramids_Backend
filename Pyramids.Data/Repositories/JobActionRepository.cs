using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pyramids.Data.Repositories
{
    public class JobActionRepository : IJobActionRepository
    {
        private readonly AppDbContext _context;

        public JobActionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JobAction> AddAsync(JobAction jobAction)
        {
            var addedJobAction = (await _context.JobActions.AddAsync(jobAction)).Entity;
            await _context.SaveChangesAsync();
            return addedJobAction;
        }

        public async Task<IEnumerable<JobAction>> GetAllAsync(int jobId)=> await _context.JobActions.Where(x => x.JobId == jobId).Include(a=>a.CreatedByUser).Include(a=>a.JobActionType).OrderByDescending(a=>a.Id).ToListAsync();
        
    }
}
