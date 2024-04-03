using Pyramids.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.IServices
{
    public interface IClientService : IService<Client>
    {
        Task<Client> GetClientByName(string name,int companyId);
    }
}
