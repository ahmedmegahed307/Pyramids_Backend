using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.IServices;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Company> _repository;
        public CompanyService(IUnitOfWork unitOfWork, IGenericRepository<Company> repository) : base(unitOfWork, repository)
        {
             _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            return await _unitOfWork.CompanyRepository.ExistsAsync(x => x.Email == email);
        }
        public async Task<bool> IsNameExist(string name)
        {
            return await _unitOfWork.CompanyRepository.ExistsAsync(x => x.Name == name);
        }

        public async Task<string> UpdateLogo(int companyId, string logoUrl)
        {
             var company = await _repository.GetByIdAsync(companyId);
            company.LogoUrl = logoUrl;

            await _unitOfWork.CommitAsync();
            return company.LogoUrl;
         
        }
    }
}
