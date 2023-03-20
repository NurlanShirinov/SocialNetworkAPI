using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Repositories.Abstract
{
    public interface IPostRepository
    {
        Task<Guid> Add(Post post);
        Task<bool> Delete(string id);
        Task Update(Post post);
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetById(string id);
        Task<ListResult<Post>> GetPaginationAsync(int offset, int limit);
    }
}
