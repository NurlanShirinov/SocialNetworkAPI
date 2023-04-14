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
    public class NotificationCommand : INotificationCommand
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private string _sqlAdd = $@"INSERT INTO Notifications [Title], [Content] , [NotificationType]
                                   VALUES(@{nameof(Notification.Title)},
                                           @{nameof(Notification.Content)},
                                            @{nameof(Notification.Type)})";

        private string _sqlDelete = $@"UPDATE Notifications SET DeleteStatus = 1 Where Id = @id";

        public async Task<Guid> Add(Notification notification)
        {
            try
            {
                var result = await _unitOfWork.GetConnection().QueryFirstOrDefaultAsync<Guid>(_sqlAdd, notification, _unitOfWork.GetTransaction());
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
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
