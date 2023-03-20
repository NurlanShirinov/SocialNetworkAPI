using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Abstract
{
    public interface IPostQuery
    {
        Task<IEnumerable<Post>> GetAllAsync();
        Task<Post> GetById(string id);
        Task<ListResult<Post>> GetPaginationAsync(int offset, int limit);



    }
}
