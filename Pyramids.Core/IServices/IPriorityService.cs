using Pyramids.Core.Models;

namespace Pyramids.Core.IServices
{
    public interface IPriorityService : IService<Priority> 
    {

        Task<Priority> GetJobPriorityByName(string name);
    }

}
