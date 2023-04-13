using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Abstract
{
    public interface IBlockedQuery
    {
        Task<IEnumerable<Blocked>> GetAllAsync();
        Task<Blocked> GetById(string id);
        Task<ListResult<Blocked>> GetPaginationAsync(int offset, int limit);

    }
}
