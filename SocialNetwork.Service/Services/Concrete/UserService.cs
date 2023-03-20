using SocialNetwork.Core.Helpers;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Add(User user)
        {
            var result = await  _userRepository.Add(user);
            return result;
        }

        public Task<bool> BlockUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckUserAsync(string email, string password)
        {
            var result = await _userRepository.CheckUserAsync(email, password);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _userRepository.Delete(id);
            return result;
        }

        public Task<IEnumerable<UserResponseModel>> GetAllAsync()
        {
            var result = _userRepository.GetAllAsync();
            return result;
        }

        public async Task<UserResponseModel> GetByIdAsync(Guid id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<ListResult<UserResponseModel>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _userRepository.GetPaginationAsync(offset, limit);
            return result;
        }

        public async Task<UserResponseModel> GetUserByEmailAsync(string email)
        {
            var result = await _userRepository.GetUserByEmailAsync(email);
            return result;
        }

        public async Task<IEnumerable<UserResponseModel>> GetUsersByNameAsync(string name)
        {
            var result = await _userRepository.GetUsersByNameAsync(name);
            return result;
        }

        public async Task Update(User user)
        {
            await _userRepository.Update(user);
        }

        public async Task UpdatePassword(string id, string password)
        {
            await _userRepository.UpdatePassword(id, password);
        }
    }
}
