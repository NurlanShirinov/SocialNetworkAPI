using SocialNetwork.Core.Models;
using SocialNetwork.Repository.Repositories.Abstract;
using SocialNetwork.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Concrete
{
    public class NotificationService : INotificationService
    {

        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Guid> Add(Notification notification)
        {
            var result = await _notificationRepository.Add(notification);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _notificationRepository.Delete(id);
            return result;
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            var result = await _notificationRepository.GetAllAsync();
            return result;
        }

        public async Task<Notification> GetById(string id)
        {
            var result = await _notificationRepository.GetById(id);
            return result;
        }
    }
}
