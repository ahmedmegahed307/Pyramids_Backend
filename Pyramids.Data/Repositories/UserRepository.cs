using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Enums;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;

namespace Pyramids.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext? AppDbContext => _context as AppDbContext;

        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetEngineers(bool isActive, int companyId)
        {
            return await AppDbContext.Users.Where(x => x.UserRole.Id == (int)UserRoleEnum.Engineer && x.IsActive == isActive && x.CompanyId == companyId).ToListAsync();
        }

        public User Get(string email)
        {
            return AppDbContext.Users.First(x => x.Email == email);
        }
        public User? GetById(int id) => AppDbContext.Users.Where(x => x.Id == id)
               .Include(x => x.UserRole)
               .FirstOrDefault();
        public async Task<User> GetEngineerByName(string name, int companyId)
        {
            var exactMatch = await AppDbContext?.Users.FirstOrDefaultAsync(c =>
             (c.FirstName.ToLower() == name.ToLower() || c.LastName.ToLower() == name.ToLower()) &&
          c.CompanyId==companyId &&
          c.UserRoleId == ((int)UserRoleEnum.Engineer));

            if (exactMatch != null)
            {
                return exactMatch;
            }

            // If no exact match is found, try to find a partial match (contains) in the first name or last name.
            var partialMatch = await AppDbContext?.Users.FirstOrDefaultAsync(c =>
         (c.FirstName.ToLower().Contains(name.ToLower()) || c.LastName.ToLower().Contains(name.ToLower())) &&
         c.CompanyId == companyId &&
         c.UserRoleId == ((int)UserRoleEnum.Engineer));

            if (partialMatch != null)
            {
                return partialMatch;
            }

            // If no partial match is found, try to find a similar sounding name in the first name or last name.
            var similarUser = await AppDbContext?.Users.FirstOrDefaultAsync(c =>
         (AppDbContext.SoundsLike(c.FirstName.ToLower()) == AppDbContext.SoundsLike(name.ToLower()) ||
          AppDbContext.SoundsLike(c.LastName.ToLower()) == AppDbContext.SoundsLike(name.ToLower())) &&
          c.CompanyId == companyId &&
         c.UserRoleId == ((int)UserRoleEnum.Engineer));

            if (similarUser != null)
            {
                return similarUser;
            }

            // If no match is found in any condition, return null.
            return null;

        }
    }
}
