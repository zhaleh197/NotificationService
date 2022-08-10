using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification;
using Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS;
//using Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Delete;
using Notification.Application.ApplicationbyMediator.UserApplication.Queries.GetById;
//using Notification.Application.Service.User.Enroll;

namespace NotificationAPICQRS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
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
            var re = _mediator.Send(command); 
            return Ok(re);
        }


















    }
}