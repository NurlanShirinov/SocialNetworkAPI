using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Abstract
{
    public interface IUserService
    {
        Task<UserResponseModel> GetByIdAsync(Guid id);
        Task<IEnumerable<UserResponseModel>> GetAllAsync();
        Task<IEnumerable<UserResponseModel>> GetUsersByNameAsync(string name);
        Task<UserResponseModel> GetUserByEmailAsync(string email);
        Task<bool> CheckUserAsync(string email, string password);
        Task<ListResult<UserResponseModel>> GetPaginationAsync(int offset, int limit);
        Task<int> Add(User user);
        Task<bool> Delete(string id);
        Task Update(User user);
        Task<bool> BlockUser(User user);
        Task UpdatePassword(string id, string password);

    }
}
