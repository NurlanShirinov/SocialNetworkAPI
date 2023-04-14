using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Models;
using SocialNetwork.Service.Services.Abstract;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _notificationService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery]string id)
        {
            var result = await _notificationService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Notification notification)
        {
            var result = await _notificationService.Add(notification);
            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await _notificationService.Delete(id);
            return Ok(result);
        }
    }
}
