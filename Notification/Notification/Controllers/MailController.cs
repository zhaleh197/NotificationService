using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Service.WriteRepository.Email.Commands;
using Notification.Application.Service.Email.Queris.Get;
using Notification.Application.Service.Notification.Queris.Get;

namespace NotificationAPI.Controllers
{
    //[Route("api/[controller]")]

    [Route("api /[controller] /[action]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IGetNotification _getClientEmails;

        public MailController(IMailService mailService, IGetNotification getClientEmails)
        {
            _mailService = mailService;
            _getClientEmails= getClientEmails;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var result= _getClientEmails.GetClientEmail();
        //    return Ok(result);
        //}

        //[HttpPost]
        //public IActionResult Send([FromForm]MailRequest email)
        //{
        //   var result=  _mailService.SendEmailAsync(email);
        //    return Ok(result);
        //}
        
        [HttpPost]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await _mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        //// GET api/<SMSController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<SMSController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SMSController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SMSController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
