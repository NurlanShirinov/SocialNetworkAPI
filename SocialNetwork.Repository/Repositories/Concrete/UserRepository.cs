using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.RequestModels;
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
    public class UserRepository : IUserRepository
    {

        private readonly IUserCommand _userCommand;
        private readonly IUserQuery _userQuery;

        public UserRepository(IUserCommand userCommand, IUserQuery userQuery)
        {
            _userCommand = userCommand;
            _userQuery = userQuery;
        }

        public async Task<RegisterResponseModel> Add(RegisterRequestModel user)
        {
            var result = await _userCommand.Add(user);
            return result;
        }

        public Task<bool> BlockUser(User user)
        {
            throw new NotImplementedException();
        }


        public async Task<LoginResponseModel> CheckUserAsync(string email, string password)
        {
            var result = await _userQuery.CheckUserAsync(email, password);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _userCommand.Delete(id);
            return result;
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllAsync()
        {
            var result = await _userQuery.GetAllAsync();
            return result;
        }

        public async Task<UserResponseModel> GetByIdAsync(Guid id)
        {
            var result = await _userQuery.GetByIdAsync(id);
            return result;
        }

        public async Task<ListResult<UserResponseModel>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _userQuery.GetPaginationAsync(offset, limit);
            return result;
        }

        public async Task<UserResponseModel> GetUserByEmailAsync(string email)
        {
            var result = await _userQuery.GetUserByEmailAsync(email);
            return result;
        }

        public async Task<IEnumerable<UserResponseModel>> GetUsersByNameAsync(string name)
        {
            var result = await _userQuery.GetUsersByNameAsync(name);
            return result;
        }

        public async Task Update(User user)
        {
           await _userCommand.Update(user);
        }

        public async Task UpdatePassword(string id, string password)
        {
            await _userCommand.UpdatePassword(id, password);
        }
    }
}
