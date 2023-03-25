using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.RequestModels;
using SocialNetwork.Service.Services.Abstract;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var result = await _userService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetUserByEmail([FromQuery] string email)
        {
            var result = await _userService.GetUserByEmailAsync(email);
            return Ok(result);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetUserByName([FromQuery] string name)
        {
            var result = await _userService.GetUsersByNameAsync(name);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var result = await _userService.CheckUserAsync(model.Email, model.Password);
            return Ok(result);
        }

        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] int offset , [FromQuery] int limit)
        {
            var result = await _userService.GetPaginationAsync(offset, limit);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Post([FromBody] RegisterRequestModel model)
        {
            var result = await _userService.Add(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            await _userService.Update(user);
            return Ok();
        }

        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> PutPassword([FromQuery] string id, string password)
        {
            await _userService.UpdatePassword(id, password);
            return Ok();
        }
    }
}