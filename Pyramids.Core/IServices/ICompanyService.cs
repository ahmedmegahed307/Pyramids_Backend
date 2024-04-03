using Pyramids.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.IServices
{
    public interface ICompanyService : IService<Company>
    {
        Task<bool> IsNameExist(string name);
        Task<bool> IsEmailExist(string email);
        Task<string> UpdateLogo(int companyId ,string logoUrl);


    }
}
