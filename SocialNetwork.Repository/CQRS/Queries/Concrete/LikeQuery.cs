using Dapper;
using SocialNetwork.Core.Models;
using SocialNetwork.Repository.CQRS.Queries.Abstract;
using SocialNetwork.Repository.Infrustruce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Concrete
{
    public class LikeQuery : ILikeQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlGetAll = $@" SELECT * FROM LIKES WHERE DeleteStatus = 0";

        private string _sqlGetById = $@"SELECT * FROM LIKES WHERE DeleteStatus =0 AND Id=@id";

        private string _sqlGetLikeCount = $@"Select COUNT(L.UserId)
FROM Likes as L
WHERE L.PostId = @postId";
        public async Task<IEnumerable<Like>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<Like>(_sqlGetAll, null, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Like> GetById(string id)
        {

            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Like>(_sqlGetById, new { id }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<int> GetLikeCount(string postId)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().ExecuteScalarAsync<int>(_sqlGetLikeCount, new { postId }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
