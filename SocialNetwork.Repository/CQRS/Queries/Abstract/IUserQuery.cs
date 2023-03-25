using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Abstract
{
    public interface IUserQuery
    {
        Task<UserResponseModel> GetByIdAsync(Guid id);
        Task<IEnumerable<UserResponseModel>> GetAllAsync();
        Task<IEnumerable<UserResponseModel>> GetUsersByNameAsync(string name);
        Task<UserResponseModel> GetUserByEmailAsync(string email);
        Task<LoginResponseModel> CheckUserAsync(string email, string password);
        Task<ListResult<UserResponseModel>> GetPaginationAsync(int offset, int limit);
    }
}
