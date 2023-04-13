using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Repository.Repositories.Abstract;
using SocialNetwork.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Concrete
{
    public class BlockedService : IBlockedService
    {

        private readonly IBlockedRepository _blockedRepository;

        public BlockedService(IBlockedRepository blockedRepository)
        {
            _blockedRepository = blockedRepository;
        }

        public async Task<Guid> Add(Blocked blocked)
        {
            var result = await _blockedRepository.Add(blocked);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _blockedRepository.Delete(id);
            return result;
        }

        public async Task<IEnumerable<Blocked>> GetAllAsync()
        {
            var result = await _blockedRepository.GetAllAsync();
            return result;
        }

        public async Task<Blocked> GetById(string id)
        {
            var result = await _blockedRepository.GetById(id);
            return result;
        }

        public async Task<ListResult<Blocked>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _blockedRepository.GetPaginationAsync(offset, limit);
            return result;
        }

        public async Task Update(string friendId)
        {
            await _blockedRepository.Update(friendId);
        }
    }
}
