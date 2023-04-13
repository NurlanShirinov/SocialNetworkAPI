using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Abstract
{
    public interface IBlockedService
    {
        Task<IEnumerable<Blocked>> GetAllAsync();
        Task<Blocked> GetById(string id);
        Task<ListResult<Blocked>> GetPaginationAsync(int offset, int limit);
        Task<Guid> Add(Blocked blocked);
        Task<bool> Delete(string id);
        Task Update(string friendId);
    }
}
