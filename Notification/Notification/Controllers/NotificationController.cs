using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Service.Notification.Commands;

namespace NotificationAPI.Controllers
{

    [Route("api /[controller] /[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService; 


        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpPost]
        public async Task<IActionResult> SendNotifi([FromForm] NotificationModel request)
        {
            try
            {
                await _notificationService.SendNotification(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
