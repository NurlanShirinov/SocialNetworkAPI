using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Abstract
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification> GetById(string id);
        Task<Guid> Add(Notification notification);
        Task<bool> Delete(string id);
    }
}
