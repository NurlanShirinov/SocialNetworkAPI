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
    public class BlockedCommand : IBlockedCommand
    {

        private readonly IUnitOfWork _unitOfWork;

        public BlockedCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlAdd = $@"INSERT INTO BLOCKED [UserId],[FriendId]
                                    VALUES(@{nameof(Blocked.UserId)}
                                           @{nameof(Blocked.FriendId)})";

        private string _sqlDelete = $@"UPDATE Blocked SET DeleteStatus = 1";

        private string _sqlUpdate = $@"UPDATE Blocked SET DeleteStatus=0 WHERE FriendID = @friendId";

        public async Task<Guid> Add(Blocked blocked)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Guid>(_sqlAdd, blocked, _unitOfWork.GetTransaction());
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
                return result!=null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(string friendId)
        {
            await _unitOfWork.GetConnection().QueryAsync(_sqlUpdate, new { friendId }, _unitOfWork.GetTransaction());
        }
    }
}
