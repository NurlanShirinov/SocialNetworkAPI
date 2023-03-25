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
    public class PostQuery : IPostQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlGetAll = $@"SELECT P.*,C.Content CommentContent, U.Name +' '+ U.Surname AS FullName FROM Posts P
LEFT JOIN Users U ON U.Id = P.UserId
LEFT JOIN Comments C ON C.PostId = P.Id
WHERE (P.UserId in (SELECT FriendId FROM Friends
WHERE UserId = @userId) OR P.UserId=@userId)
ORDER BY P.CreatedDate DESC
";

        private string _sqlGetById = $@"SELECT * FROM POSTS WHERE Id=@id AND DeleteStatus = 0";

        private string _sqlGetAllPaging = $@"SELECT P.* 
                                             FROM POSTS  AS P
                                             WHERE P.DeleteStatus=0
                                             ORDER BY P.[CreatedDate] DESC
                                             OFFSET @Offset ROWS
                                             FETCH NEXT @Limit ROWS ONLY
                                             SELECT COUNT(Id) 
                                             FROM POSTS
                                             WHERE DeleteStatus=0";


        public async Task<IEnumerable<PostResponseModels>> GetAllAsync(string userId)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<PostResponseModels>(_sqlGetAll, new { userId }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Post> GetById(string id)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Post>(_sqlGetById, new { id }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ListResult<Post>> GetPaginationAsync(int offset, int limit)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryMultipleAsync(_sqlGetAllPaging, new { offset, limit, }, _unitOfWork.GetTransaction());
                var res = new ListResult<Post>
                {
                    List = result.Read<Post>(),
                    TotalCount = result.ReadFirst<int>()
                };
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
