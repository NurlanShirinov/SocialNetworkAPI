using Dapper;
using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
using SocialNetwork.Repository.CQRS.Queries.Abstract;
using SocialNetwork.Repository.Infrustruce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Concrete
{

    public class UserQuery : IUserQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        private string _sqlCheckUser = $@"SELECT * FROM USERS WHERE Email = @email AND Password = @password AND DELETESTATUS=0";

        private string _sqlGetAll = $@"SELECT * FROM USERS WHERE DELETESTATUS=0";

        private string _sqlGetById = $@"SELECT * FROM USERS WHERE Id=@id AND DELETESTATUS=0";

        private string _sqlGetByEmail = $@"SELECT * FROM USERS WHERE Email=@email AND DELETESTATUS=0";
        private string _sqlGetByName = $@"SELECT * FROM USERS WHERE Name=@name AND DELETESTATUS=0";


        private string _sqlGetAllPaging = $@"Select U.*
       FROM USERS AS U
	   Where U.DeleteStatus = 0
       ORDER BY U.[CreatedDate] DESC
       OFFSET @Offset ROWS
       FETCH NEXT @Limit ROWS ONLY
	   Select Count(Id)
	   From Users 
	   Where DeleteStatus = 0";

        public async Task<LoginResponseModel> CheckUserAsync(Email email, string password)
        {
            var param = new
            {
                email = email.EmailValue,
                password
            };
            try
            {
                var currentUser = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<UserResponseModel>(_sqlCheckUser, param, _unitOfWork.GetTransaction());
                if (currentUser is null)
                {
                    var result = new LoginResponseModel { UserId = Guid.Empty.ToString(), SuccesfulLogin = false };
                    return result;
                }
                else
                {
                    var result = new LoginResponseModel { UserId = currentUser.Id.ToString(), SuccesfulLogin = true };
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<UserResponseModel>(_sqlGetAll, null, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserResponseModel> GetByIdAsync(Guid id)
        {
            var param = new { id };
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<UserResponseModel>(_sqlGetById, param, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ListResult<UserResponseModel>> GetPaginationAsync(int offset, int limit)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryMultipleAsync(_sqlGetAllPaging, new { offset, limit }, _unitOfWork.GetTransaction());

                var res = new ListResult<UserResponseModel>
                {
                    List = result.Read<UserResponseModel>(),
                    TotalCount = result.ReadFirst<int>()
                };

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<UserResponseModel> GetUserByEmailAsync(string email)
        {
            var param = new { email };

            try
            {
                var result = _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<UserResponseModel>(_sqlGetByEmail, param, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<UserResponseModel>> GetUsersByNameAsync(string name)
        {
            var param = new { name };
            try
            {
                var result = _unitOfWork.GetConnection().QueryAsync<UserResponseModel>(_sqlGetByName, param, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
