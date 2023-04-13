using SocialNetwork.Core.Models;
using SocialNetwork.Repository.Repositories.Abstract;
using SocialNetwork.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Service.Services.Concrete
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }



        public async Task<Guid> Add(Like like)
        {
            var result = await _likeRepository.Add(like);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _likeRepository.Delete(id);
            return result;
        }

        public async Task<IEnumerable<Like>> GetAllAsync()
        {
            var result = await _likeRepository.GetAllAsync();
            return result;
        }

        public async Task<Like> GetById(string id)
        {
            var result = await _likeRepository.GetById(id);
            return result;
        }

        public async Task<int> GetLikeCount(string postId)
        {
            var result = await _likeRepository.GetLikeCount(postId);
            return result;
        }

        public async Task Update(Like like)
        {
            await _likeRepository.Update(like);
        }
    }
}
