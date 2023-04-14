using Dapper;
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
    public class NotificationQuery : INotificationQuery
    {

        private readonly IUnitOfWork _unitOfWork;

        public NotificationQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlGetAll = $@"SELECT * FROM Notifications Where DeleteStatus = 0";

        private string _sqlGetById = $@"SELECT * FROM Notifications WHERE Id=@id AND DeleteStatus = 0";

        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryAsync<Notification>(_sqlGetAll, null, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception )
            {
                throw ;
            }
        }

        public async Task<Notification> GetById(string id)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Notification>(_sqlGetById, new { id }, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
