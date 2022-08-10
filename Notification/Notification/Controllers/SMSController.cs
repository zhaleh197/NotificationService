using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Service.SMS.Commands;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotificationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _sMSService; 

        public SMSController(ISMSService sMSService)
        {
            _sMSService = sMSService;
        }

        [HttpPost]
        public IActionResult SendSMS([FromBody] SMSSendRequest request)
        {
            _sMSService.SMS(request);
            return Ok();
        }

        [HttpPost]    
        public IActionResult SendSMSF([FromBody] SMSSendRequest2 request)
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier); 
            _sMSService.SMSF(request);
            return Ok("test api by get token- send sms");
        }


    }
}
