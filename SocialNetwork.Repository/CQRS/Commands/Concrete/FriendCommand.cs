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
    public class FriendCommand : IFriendCommand
    {

        private readonly IUnitOfWork _unitOfWork;

        public FriendCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlAdd = $@"INSERT INTO Friends ([UserId], [FriendId])
                                    VALUES(@{nameof(Friend.UserId)}
                                           @{nameof(Friend.FriendId)})";

        private string _sqlDelete = $@"UPDATE Friends SET DeleteStatus = 1 WHERE UserId = @userId";

        public async Task<Guid> Add(Friend friend)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Guid>(_sqlAdd, friend, _unitOfWork.GetTransaction());
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
    }
}
