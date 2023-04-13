using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Service.Services.Abstract;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockedController : ControllerBase
    {
        private readonly IBlockedService _blockedService;

        public BlockedController(IBlockedService blockedService)
        {
            _blockedService = blockedService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _blockedService.GetAllAsync();
                return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var result = await _blockedService.GetById(id);
            return Ok(result);
        }

        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] int limit, [FromQuery] int offset)
        {
            var result = await _blockedService.GetPaginationAsync(limit, offset);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blocked blocked)
        {
            var result = await _blockedService.Add(blocked);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete( [FromQuery] string id)
        {
            var result = await _blockedService.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] string friendId)
        {
             await _blockedService.Update(friendId);
            return Ok();
        }
    }
}
