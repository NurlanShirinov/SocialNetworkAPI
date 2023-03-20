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
    public class CommentCommand : ICommentCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlAddComment = $@"INSERT INTO COMMENTS([Content],[UserId],[PostId])
                                           VALUES(@{nameof(Comment.Content)},
                                                  @{nameof(Comment.UserId)},
                                                  @{nameof(Comment.PostId)})";

        private string _sqlDeleteComment = $@"UPDATE COMMENTS
                                              SET DeleteStatus = 1 WHERE Id=@id";

        private string _sqlUpdateComment = $@"UPDATE COMMENTS
                                              SET Content=@content
                                              WHERE Id=@id";
        public async Task<Guid> Add(Comment comment)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Guid>(_sqlAddComment, comment, _unitOfWork.GetTransaction());
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<bool>(_sqlDeleteComment, new { id }, _unitOfWork.GetTransaction());
                return result != null;
            }
            catch 
            {
                throw;
            }
        }

        public async Task Update(Comment comment)
        {
            try
            {
                await _unitOfWork.GetConnection().QueryAsync<bool>(_sqlUpdateComment, comment, _unitOfWork.GetTransaction());
            }
            catch
            {
                throw;
            }
        }
    }
}
