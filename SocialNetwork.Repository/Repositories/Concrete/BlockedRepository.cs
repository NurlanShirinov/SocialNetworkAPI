using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Repository.CQRS.Commands.Abstract;
using SocialNetwork.Repository.CQRS.Queries.Abstract;
using SocialNetwork.Repository.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Repositories.Concrete
{
    public class BlockedRepository : IBlockedRepository
    {
        private readonly IBlockedCommand _blockedCommand;
        private readonly IBlockedQuery _blockedQuery;

        public BlockedRepository(IBlockedCommand blockedCommand, IBlockedQuery blockedQuery)
        {
            _blockedCommand = blockedCommand;
            _blockedQuery = blockedQuery;
        }

        public async Task<Guid> Add(Blocked blocked)
        {
            var result = await _blockedCommand.Add(blocked);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _blockedCommand.Delete(id);
            return result;
        }

        public async Task<IEnumerable<Blocked>> GetAllAsync()
        {
            var result = await _blockedQuery.GetAllAsync();
            return result;
        }

        public async Task<Blocked> GetById(string id)
        {
            var result = await _blockedQuery.GetById(id);
            return result;
        }

        public async Task<ListResult<Blocked>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _blockedQuery.GetPaginationAsync(offset, limit);
            return result;
        }

        public async Task Update(string friendId)
        {
            await _blockedCommand.Update(friendId);
        }
    }
}
