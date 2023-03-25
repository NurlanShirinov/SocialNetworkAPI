using SocialNetwork.Core.Models;
using SocialNetwork.Core.RequestModels;
using SocialNetwork.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Commands.Abstract
{
    public interface IUserCommand
    {
        Task<RegisterResponseModel> Add(RegisterRequestModel user);
        Task<bool> Delete(string id);
        Task Update(User user);
        Task UpdatePassword(string id, string password);
        Task<bool> BlockUser(User user);
    }
}
