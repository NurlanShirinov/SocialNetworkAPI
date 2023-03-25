using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.RequestModels;
using SocialNetwork.Core.ResponseModels;
using SocialNetwork.Repository.CQRS.Commands.Abstract;
using SocialNetwork.Repository.CQRS.Queries.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Repositories.Abstract
{
    public interface IUserRepository
    {
        Task<UserResponseModel> GetByIdAsync(Guid id);
        Task<IEnumerable<UserResponseModel>> GetAllAsync();
        Task<IEnumerable<UserResponseModel>> GetUsersByNameAsync(string name);
        Task<UserResponseModel> GetUserByEmailAsync(string email);
        Task<LoginResponseModel> CheckUserAsync(string email, string password);
        Task<ListResult<UserResponseModel>> GetPaginationAsync(int offset, int limit);
        Task<RegisterResponseModel> Add(RegisterRequestModel user);
        Task<bool> Delete(string id);
        Task Update(User user);
        Task<bool> BlockUser(User user);
        Task UpdatePassword(string id, string password);

    }
}
