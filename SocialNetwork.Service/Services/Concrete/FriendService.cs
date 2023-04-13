using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
using SocialNetwork.Repository.Repositories.Abstract;
using SocialNetwork.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Concrete
{
    public class FriendService : IFriendService
    {

        private readonly IFriendRepository _friendRepository;

        public FriendService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<Guid> Add(Friend friend)
        {
           var resutl = await _friendRepository.Add(friend);
            return resutl;
        }

        public async Task<bool> Delete(string id)
        {
            var result =  await _friendRepository.Delete(id);
            return result;
        }

        public async Task<IEnumerable<FriendResponseModel>> GetAllAsync(string userId)
        {
            var result = await _friendRepository.GetAllAsync(userId);
            return result;
        }

        public async Task<Friend> GetById(string id)
        {
            var result = await _friendRepository.GetById(id);
            return result;
        }

        public async Task<IEnumerable<FriendResponseModel>> GetNewFriends(string userId)
        {
            var result = await _friendRepository.GetNewFriends(userId);
            return result;
        }
    }
}
