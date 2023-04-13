using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Service.Services.Abstract;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLikes()
        {
            var result = await _likeService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var result = await _likeService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetLikeCount")]
        public async Task<IActionResult> GetLikeCount([FromQuery] string postId)
        {
            var result = await _likeService.GetLikeCount(postId);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await _likeService.Delete(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Like like)
        {
            var result = await _likeService.Add(like);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put ([FromBody] Like like)
        {
            await _likeService.Add(like);
            return Ok();
        }

    }
}
