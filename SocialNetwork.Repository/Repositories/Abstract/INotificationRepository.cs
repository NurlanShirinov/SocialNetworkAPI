using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Repositories.Abstract
{
    public interface INotificationRepository
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification> GetById(string id);
        Task<Guid> Add(Notification notification);
        Task<bool> Delete(string id);
    }
}
