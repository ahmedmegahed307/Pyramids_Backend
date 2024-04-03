using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyramids.Core.Models;
using Pyramids.Core.Models.AI;

namespace Pyramids.Core.IServices
{
    public interface IAIService
    {
        Task<int> ClassifyTextAsync(TextProcessingRequest request);
        Task<AILogJobResponse> GetJobInfoByAI(string userInput,int companyId);
        Task<IEnumerable<Job>> JobQueryReportByAI(string userInput, int userId, int companyId);
        //Task<string> CompleteSentenceAdvance(string text);
    }
}
