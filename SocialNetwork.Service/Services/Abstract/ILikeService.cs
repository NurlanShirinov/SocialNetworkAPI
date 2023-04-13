using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Abstract
{
    public interface ILikeService
    {
        Task<Guid> Add(Like like);
        Task<bool> Delete(string id);
        Task Update(Like like);
        Task<IEnumerable<Like>> GetAllAsync();
        Task<Like> GetById(string id);
        Task<int> GetLikeCount(string postId);

    }
}
