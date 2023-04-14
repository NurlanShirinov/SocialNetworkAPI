using Dapper;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.RequestModels;
using SocialNetwork.Core.ResponseModels;
using SocialNetwork.Repository.CQRS.Commands.Abstract;
using SocialNetwork.Repository.Infrustruce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Commands.Concrete
{
    public class UserCommand : IUserCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlAddUser = $@"INSERT INTO USERS ([Name],[Surname],[Email],[Password])
                                       OUTPUT INSERTED.Id
                                     VALUES (@{nameof(RegisterRequestModel.Name)},
                                            @{nameof(RegisterRequestModel.Surname)},
                                            @{nameof(RegisterRequestModel.Email)},
                                            @{nameof(RegisterRequestModel.Password)})";
        
        private string _sqlDeleteUser = $@"UPDATE USERS
                                           SET DeleteStatus = 1
                                           WHERE Id=@id";
                                           
        private string _sqlUpdateUser = $@"UPDATE USERS
                                       SET Name = @{nameof(User.Name)},
                                        Surname = @{nameof(User.Surname)},
                                        Email = @{nameof(User.Email)}
                                       WHERE Id= @{nameof(User.Id)}";

        private string _sqlUpdatePassword = $@"UPDATE USERS
                                                SET Password = @{nameof(User.Password)}
                                                WHERE Id=@{nameof(User.Id)}";

        public async Task<RegisterResponseModel> Add(RegisterRequestModel user)
        {
            try
            {
                new Email { EmailValue = user.Email };
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Guid>(_sqlAddUser, user, _unitOfWork.GetTransaction());
                var registerResponseModel = new RegisterResponseModel { UserId = result.ToString(), SuccesfulLogin = true };
                return registerResponseModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(string id)
        {
            var param = new { id };
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<bool>(_sqlDeleteUser, param, _unitOfWork.GetTransaction());
                return result != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(User user)
        {
            try
            {
                await _unitOfWork.GetConnection().QueryAsync(_sqlUpdateUser, user, _unitOfWork.GetTransaction());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> BlockUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePassword(string id, string password)
        {
            var param = new
            {
                id,
                password
            };
            try
            {
                await _unitOfWork.GetConnection().QueryAsync(_sqlUpdatePassword, param, _unitOfWork.GetTransaction());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
