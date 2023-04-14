using SocialNetwork.Core.Models;
using SocialNetwork.Repository.CQRS.Commands.Abstract;
using SocialNetwork.Repository.CQRS.Queries.Abstract;
using SocialNetwork.Repository.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Repositories.Concrete
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly INotificationCommand _notificationCommand;
        private readonly INotificationQuery _notificationQuery;

        public NotificationRepository(INotificationCommand notificationCommand, INotificationQuery notificationQuery)
        {
            _notificationCommand = notificationCommand;
            _notificationQuery = notificationQuery;
        }

        public async Task<Guid> Add(Notification notification)
        {
            var result = await _notificationCommand.Add(notification);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _notificationCommand.Delete(id);
            return result;
        }

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            var result = await _notificationQuery.GetAllAsync();
            return result;
        }

        public async Task<Notification> GetById(string id)
        {
            var result = await _notificationQuery.GetById(id);
            return result;
        }
    }
}
