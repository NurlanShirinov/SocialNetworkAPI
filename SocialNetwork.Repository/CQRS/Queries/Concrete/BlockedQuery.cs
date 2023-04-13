using Dapper;
using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Repository.CQRS.Commands.Abstract;
using SocialNetwork.Repository.CQRS.Queries.Abstract;
using SocialNetwork.Repository.Infrustruce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Concrete
{
    public class BlockedQuery : IBlockedQuery
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlockedQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlGetAll = $@"SELECT * FROM Blocked WHERE DeleteStatus = 1";

        private string _sqlGetById = $@"SELECT * FROM Blocked WHERE Id = @id AND DeleteStatus = 1";

        private string _sqlGetAlPaginig = $@"SELECT B.* 
                                             FROM Blocked  AS B
                                             WHERE B.DeleteStatus=1
                                             OFFSET @Offset ROWS
                                             FETCH NEXT @Limit ROWS ONLY
                                             SELECT COUNT(Id) 
                                             FROM Comments
                                             WHERE DeleteStatus=1";
        public async Task<IEnumerable<Blocked>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<Blocked>(_sqlGetAll, null, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Blocked> GetById(string id)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync(_sqlGetById, new { id }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ListResult<Blocked>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _unitOfWork.GetConnection().QueryMultipleAsync(_sqlGetAlPaginig, new { offset, limit, }, _unitOfWork.GetTransaction());
            var res = new ListResult<Blocked>
            {
                List = result.Read<Blocked>(),
                TotalCount = result.ReadFirst<int>()
            };
            return res;
        }
    }
}
