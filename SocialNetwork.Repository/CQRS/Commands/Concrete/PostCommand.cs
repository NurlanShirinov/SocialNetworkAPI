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
    public class PostCommand : IPostCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        private string _sqlAddPost = $@"INSERT INTO Posts ([Content],[UserId])
                                        VALUES ( @{nameof(Post.Content)},
                                                 @{nameof(Post.UserId)})";
            
        private string _sqlDeletePost = $@"UPDATE POSTS SET DeleteStatus=1 WHERE Id=@id";


        private string _sqlUpdatePost = $@"UPDATE POSTS
                                           SET Content = @content
                                           WHERE Id=@id";


        public async Task<Guid> Add(Post post)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Guid>(_sqlAddPost, post, _unitOfWork.GetTransaction());
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
                var result = await _unitOfWork.GetConnection().QueryAsync<bool>(_sqlDeletePost, new { id }, _unitOfWork.GetTransaction());
                return result != null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Update(Post post)
        {
            try
            {
                await _unitOfWork.GetConnection().QueryAsync(_sqlUpdatePost, post, _unitOfWork.GetTransaction());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
