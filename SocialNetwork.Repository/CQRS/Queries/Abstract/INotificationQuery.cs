using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Abstract
{
    public interface INotificationQuery
    {
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification> GetById(string id);
    }
}
