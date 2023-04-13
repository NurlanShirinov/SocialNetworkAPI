using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
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
    public class FriendRepository : IFriendRepository
    {

        private readonly IFriendCommand _frienCommand;
        private readonly IFriendQuery _friendQuery;

        public FriendRepository(IFriendCommand frienCommand, IFriendQuery friendQuery)
        {
            _frienCommand = frienCommand;
            _friendQuery = friendQuery;
        }

        public async Task<Guid> Add(Friend friend)
        {
            var result = await _frienCommand.Add(friend);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _frienCommand.Delete(id);
            return result;
        }

        public async Task<IEnumerable<FriendResponseModel>> GetAllAsync(string userId)
        {
           var result = await _friendQuery.GetAllAsync(userId);
            return result;
        }

        public async Task<Friend> GetById(string id)
        {
            var result = await _friendQuery.GetById(id);
            return result;
        }

        public async Task<IEnumerable<FriendResponseModel>> GetNewFriends(string userId)
        {
            var result = await _friendQuery.GetNewFriends(userId);
            return result;
        }
    }
}
