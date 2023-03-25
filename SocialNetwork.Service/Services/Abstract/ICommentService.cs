using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Abstract
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentResponseModel>> GetAllAsync(string postIdd);
        Task<Comment> GetById(string id);
        Task<ListResult<Comment>> GetPaginationAsync(int offset, int limit);
        Task<Guid> Add(Comment comment);
        Task<bool> Delete(string id);
        Task Update(Comment comment);
    }
}
