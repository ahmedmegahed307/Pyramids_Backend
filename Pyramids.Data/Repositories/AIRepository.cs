using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Pyramids.Data.Repositories
{
    public class AIRepository : IAIRepository
    {
        protected readonly DbContext _context;

        
        public AIRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AIUserInputAccuracyTracking> AddAsync(AIUserInputAccuracyTracking entity)
        {
            var aiInput = await _context.AddAsync(entity);
            await _context.SaveChangesAsync(); 
            return aiInput.Entity;
        }



    }

}
