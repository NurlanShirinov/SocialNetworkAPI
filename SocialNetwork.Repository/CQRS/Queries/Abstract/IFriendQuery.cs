using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Abstract
{
    public interface IFriendQuery
    {
        Task<IEnumerable<FriendResponseModel>> GetAllAsync(string userId);
        Task<Friend> GetById(string id);
        Task<IEnumerable<FriendResponseModel>> GetNewFriends(string userId);
    }
}
