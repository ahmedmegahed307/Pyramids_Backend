using Pyramids.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.IServices
{
    public interface ISiteService : IService<Site>
    {
        Task<IEnumerable<Site>> GetAllSitesByClientId(int clientId);
        Task<Site> GetSiteByName(string name,int clientId);



    }
}
