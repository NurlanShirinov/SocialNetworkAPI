using Dapper;
using SocialNetwork.Core.Helpers;
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
    public class CommentQuery : ICommentQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlGetAllComments = $@"SELECT * FROM COMMENTS WHERE DeleteStatus=0";

        private string _sqlGetById = $@"SELECT * FROM COMMENTS WHERE Id=@id AND DeleteStatus = 0";

        private string _sqlGetAlPaginig = $@"SELECT C.* 
                                             FROM Comments  AS C
                                             WHERE C.DeleteStatus=0
                                             ORDER BY C.[CreatedDate] DESC
                                             OFFSET @Offset ROWS
                                             FETCH NEXT @Limit ROWS ONLY
                                             SELECT COUNT(Id) 
                                             FROM Comments
                                             WHERE DeleteStatus=0";

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<Comment>(_sqlGetAllComments, null, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Comment> GetById(string id)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Comment>(_sqlGetById, new { id }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ListResult<Comment>> GetPaginationAsync(int offset, int limit)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryMultipleAsync(_sqlGetAlPaginig, new { offset, limit, }, _unitOfWork.GetTransaction());
                var res = new ListResult<Comment>
                {
                    List = result.Read<Comment>(),
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
