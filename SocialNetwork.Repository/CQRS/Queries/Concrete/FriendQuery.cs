using Dapper;
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
    public class FriendQuery : IFriendQuery
    {

        private readonly IUnitOfWork _unitOfWork;

        public FriendQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlGetAll = $@"SELECT F.*, CONCAT(U.Name, ' ', U.Surname) AS Fullname  
from Friends AS F 
LEFT JOIN Users AS U
on F.UserId = @userId
WHERE U.id = F.FriendId AND F.DeleteStatus = 0";

        private string _sqlGetById = $@"SELECT * FROM Frinds WHERE FriendId = @friendId AND DeleteStatus =0";

        private string _sqlGetNewFriends = $@"SELECT DISTINCT U.*, CONCAT(U.Name, ' ', U.Surname) AS Fullname 
                                              FROM Users AS U
                                              LEFT JOIN Friends AS F
                                              ON U.Id = F.FriendId AND F.UserId = @userId
                                              WHERE U.Id != @userId AND F.FriendId IS NULL;";

        public async Task<IEnumerable<FriendResponseModel>> GetAllAsync(string userId)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<FriendResponseModel>(_sqlGetAll, new { userId }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Friend> GetById(string id)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Friend>(_sqlGetById, new { id }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<FriendResponseModel>> GetNewFriends(string userId)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<FriendResponseModel>(_sqlGetNewFriends, new { userId }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}