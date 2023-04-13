using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
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
    public class PostRepository : IPostRepository
    {

        private readonly IPostQuery _postQuery;
        private readonly IPostCommand _postCommand;

        public PostRepository(IPostQuery postQuery, IPostCommand postCommand)
        {
            _postQuery = postQuery;
            _postCommand = postCommand;
        }

        public async Task<Guid> Add(Post post)
        {
            var result = await _postCommand.Add(post);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _postCommand.Delete(id);
            return result;
        }

        public async Task<IEnumerable<PostResponseModels>> GetAllAsync(string userId)
        {
            var result = await _postQuery.GetAllAsync(userId);
            return result;
        }

        public async Task<IEnumerable<PostResponseModels>> GetAllOwn(string userId)
        {
            var result = await _postQuery.GetAllOwn(userId);
            return result;
        }

        public async Task<Post> GetById(string id)
        {
            var result = await _postQuery.GetById(id);
            return result;
        }

        public async Task<ListResult<Post>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _postQuery.GetPaginationAsync(offset, limit);
            return result;
        }

        public async Task Update(Post post)
        {
            await _postCommand.Update(post);
        }
    }
}
