using SocialNetwork.Core.Models;
using SocialNetwork.Repository.CQRS.Commands.Abstract;
using SocialNetwork.Repository.CQRS.Queries.Abstract;
using SocialNetwork.Repository.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.Repositories.Concrete
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ILikeCommand _likeCommand;
        private readonly ILikeQuery _likeQuery;

        public LikeRepository(ILikeCommand likeCommand, ILikeQuery likeQuery)
        {
            _likeCommand = likeCommand;
            _likeQuery = likeQuery;
        }

        public async Task<Guid> Add(Like like)
        {
            var result = await _likeCommand.Add(like);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _likeCommand.Delete(id);
            return result;
        }

        public async Task<IEnumerable<Like>> GetAllAsync()
        {
            var result = await _likeQuery.GetAllAsync();
            return result;
        }

        public async Task<Like> GetById(string id)
        {
            var result = await _likeQuery.GetById(id);
            return result;
        }

        public async Task<int> GetLikeCount(string postId)
        {
            var result = await _likeQuery.GetLikeCount(postId);
            return result;
        }

        public async Task Update(Like like)
        {
            await _likeCommand.Update(like);
        }
    }
}
