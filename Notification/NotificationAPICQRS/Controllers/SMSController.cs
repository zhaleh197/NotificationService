using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification;
using Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS;
//using Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Delete;
using Notification.Application.ApplicationbyMediator.UserApplication.Queries.GetById;
using System.Security.Claims;
//using Notification.Application.Service.User.Enroll;

namespace NotificationAPICQRS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class SMSController : Controller
    {

        private readonly IMediator _mediator;
        public SMSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendSMS(AddSMSinQRequest command)
        {
            //var userId = User?.FindFirst(ClaimTypes.NameIdentifier);
            //var userphone= User?.FindFirst(ClaimTypes.MobilePhone);
            //command.userOfSMS.PhoneUser = userphone.Value;
           
            var re = await _mediator.Send(command); 
            return Ok(re);
        }


















    }
}