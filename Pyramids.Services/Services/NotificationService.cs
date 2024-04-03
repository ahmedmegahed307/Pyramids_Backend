using Pyramids.Core.IServices;
using Pyramids.Core.Models;
using Pyramids.Core.Repositories;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Service.Services
{

    public class NotificationService : Service<Notification>, INotificationService
    {
        public NotificationService(IUnitOfWork unitOfWork, IGenericRepository<Notification> repository) : base(unitOfWork, repository)
        {
        }
    }
}
