using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Service.Services.Abstract;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllComments([FromQuery] string postId)
        {
            var result = await _commentService.GetAllAsync(postId);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var result = await _commentService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination([FromQuery] int limit, [FromQuery] int offset)
        {
            var result = await _commentService.GetPaginationAsync(limit, offset);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await _commentService.Delete(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comment comment)
        {
            var result = await _commentService.Add(comment);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Comment comment)
        {
            await _commentService.Update(comment);
            return Ok();
        }
    }
}
