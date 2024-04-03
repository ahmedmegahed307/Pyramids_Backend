using Pyramids.Core.Models;

namespace Pyramids.Core.Repositories
{
    public interface IAIRepository
    {
        Task<AIUserInputAccuracyTracking> AddAsync(AIUserInputAccuracyTracking entity);
    }
   
}
