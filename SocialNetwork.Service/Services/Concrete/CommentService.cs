using SocialNetwork.Core.Helpers;
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
    public class CommentService : ICommentService
    {

        private readonly ICommentRepository _commenRepository;

        public CommentService(ICommentRepository commenRepository)
        {
            _commenRepository = commenRepository;
        }

        public async Task<Guid> Add(Comment comment)
        {
            var result = await _commenRepository.Add(comment);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _commenRepository.Delete(id);
            return result;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            var result = await _commenRepository.GetAllAsync();
            return result;
        }

        public async Task<Comment> GetById(string id)
        {
            var result = await _commenRepository.GetById(id);
            return result;
        }

        public async Task<ListResult<Comment>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _commenRepository.GetPaginationAsync(offset, limit);
            return result;
        }

        public async Task Update(Comment comment)
        {
            await _commenRepository.Update(comment);
        }
    }
}
