using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Service.Services.Abstract;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string userId)
        {
            var result = await _postService.GetAllAsync(userId);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var result = await _postService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] int limit, [FromQuery] int offset)
        {
            var result = await _postService.GetPaginationAsync(limit, offset);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            var result = await _postService.Add(post);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await _postService.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Post post)
        {
            await _postService.Update(post);
            return Ok();
        }

    }
}
