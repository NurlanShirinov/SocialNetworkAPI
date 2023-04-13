using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Abstract
{
    public interface ILikeQuery
    {
        Task<IEnumerable<Like>> GetAllAsync();
        Task<Like> GetById(string id);
        Task<int> GetLikeCount(string postId);
    }
}
