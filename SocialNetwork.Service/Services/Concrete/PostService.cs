using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
using SocialNetwork.Repository.Repositories.Abstract;
using SocialNetwork.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Concrete
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Guid> Add(Post post)
        {
           var result = await _postRepository.Add(post);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _postRepository.Delete(id);
            return result;
        }

        public async Task<IEnumerable<PostResponseModels>> GetAllAsync(string userId)
        {
            var result = await _postRepository.GetAllAsync(userId);
            return result;
        }

        public async Task<IEnumerable<PostResponseModels>> GetAllOwn(string userId)
        {
            var result = await _postRepository.GetAllOwn(userId);
            return result;
        }

        public async Task<Post> GetById(string id)
        {
            var result = await _postRepository.GetById(id);
            return result;
        }

        public async Task<ListResult<Post>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _postRepository.GetPaginationAsync(offset, limit);
            return result;
        }

        public async Task Update(Post post)
        {
            await _postRepository.Update(post);
        }
    }
}
