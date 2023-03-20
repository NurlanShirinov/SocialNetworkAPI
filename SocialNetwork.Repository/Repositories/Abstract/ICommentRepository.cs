using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Repositories.Abstract
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetAllAsync();
        Task<Comment> GetById(string id);
        Task<ListResult<Comment>> GetPaginationAsync(int offset, int limit);
        Task<Guid> Add(Comment comment);
        Task<bool> Delete(string id);
        Task Update(Comment comment);
    }
}
