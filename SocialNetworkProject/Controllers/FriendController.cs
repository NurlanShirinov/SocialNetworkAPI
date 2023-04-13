using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Service.Services.Abstract;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] string userId)
        {
            var result = await _friendService.GetAllAsync(userId);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var result = await _friendService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetNewFriends")]
        public async Task<IActionResult> GetNewFriends([FromQuery] string userId)
        {
            var result = await _friendService.GetNewFriends(userId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Friend friend)
        {
            var result = await _friendService.Add(friend);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await _friendService.Delete(id);
            return Ok(result);
        }


    }
}
