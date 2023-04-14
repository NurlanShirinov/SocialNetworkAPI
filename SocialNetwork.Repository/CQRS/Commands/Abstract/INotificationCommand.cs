using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Commands.Abstract
{
    public interface INotificationCommand
    {
        Task<Guid> Add(Notification notification);
        Task<bool> Delete(string id);
    }
}
