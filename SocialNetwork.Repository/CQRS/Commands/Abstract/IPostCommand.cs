using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Commands.Abstract
{
    public interface IPostCommand
    {
        Task<Guid> Add(Post post);
        Task<bool> Delete (string id);
        Task Update(Post post);
    }
}
