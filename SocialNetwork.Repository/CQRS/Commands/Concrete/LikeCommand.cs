using Dapper;
using SocialNetwork.Core.Models;
using SocialNetwork.Repository.CQRS.Commands.Abstract;
using SocialNetwork.Repository.Infrustruce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Commands.Concrete
{
    public class LikeCommand : ILikeCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlAdd = $@"INSERT INTO LIKES([UserId],[CommentId],[PostId])
                                    VALUES(@{nameof(Like.UserId)},
                                            @{nameof(Like.CommentId)},
                                             @{nameof(Like.PostId)})";

        private string _sqlDelete = $@"UPDATE LIKES 
                                        SET DeleteStatus = 1 WHERE Id=@id";

        private string _sqlUpdate = $@"UPDATE LIKES 
                                        SET UserId = @userId
                                        CommentId = @commentId
                                        PostId= @postId
                                        Where Id=@id";

        public async Task<Guid> Add(Like like)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Guid>(_sqlAdd, like, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<bool>(_sqlDelete, new { id }, _unitOfWork.GetTransaction());
                return result != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(Like like)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<bool>(_sqlUpdate, like, _unitOfWork.GetTransaction());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
