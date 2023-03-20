using SocialNetwork.Core.Helpers;
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
    public class CommentRepository : ICommentRepository
    {

        private readonly ICommentCommand _commentCommand;
        private readonly ICommentQuery _commentQuery;

        public CommentRepository(ICommentCommand commentCommand, ICommentQuery commentQuery)
        {
            _commentCommand = commentCommand;
            _commentQuery = commentQuery;
        }

        public async Task<Guid> Add(Comment comment)
        {
            var result = await _commentCommand.Add(comment);
            return result;
        }

        public async Task<bool> Delete(string id)
        {
            var result = await _commentCommand.Delete(id);
            return result;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            var result = await _commentQuery.GetAllAsync();
            return result;
        }

        public async Task<Comment> GetById(string id)
        {
            var result = await _commentQuery.GetById(id);
            return result;
        }

        public async Task<ListResult<Comment>> GetPaginationAsync(int offset, int limit)
        {
            var result = await _commentQuery.GetPaginationAsync(offset, limit);
            return result;
        }

        public async Task Update(Comment comment)
        {
            await _commentCommand.Update(comment);
        }
    }
}
