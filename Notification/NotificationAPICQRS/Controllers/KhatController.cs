using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.AddKhat;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.DeleteKhat;
using Notification.Application.Service.WriteRepository.User.Kat;

namespace NotificationAPICQRS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class KhatController : Controller
    { 
        //private readonly IKhat _khat; 
        //private readonly ILogger<ProjectController> _logger;
        //public KhatController(  IKhat khat, ILogger<ProjectController> logger)
        //{ 
        //    _khat = khat; 
        //    _logger = logger;
        //} 

        private readonly IMediator _mediator;
        public KhatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddKhat(AddKhatRequest command)
        {
            var re = await _mediator.Send(command);
            if (re != null)
            {
                return Ok(command);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteKhat([FromQuery] DeletKhatRequest model, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(model, cancellationToken));
        } 
        ///////////////////////////////////
        ////KHAT//
        //[HttpGet]
        //public IActionResult getallkhat()
        //{
        //    _logger.LogInformation("get all khat");
        //    return Ok(_khat.GetAllKhatUsers());
        //}
        //[HttpGet("{id}")]
        //public IActionResult getkhatbyiduser([FromRoute] long id)
        //{
        //    _logger.LogInformation("get khat {0}", id);
        //    return Ok(_khat.GetKhatbyIdUser(id));
        //}

        //[HttpGet("{id}")]
        //public IActionResult getkhatbyidkhat([FromRoute] long id)
        //{
        //    _logger.LogInformation("get khat by {0} pro", id);
        //    return Ok(_khat.GetKhatbyId(id));
        //}

        //[HttpPost]
        //public IActionResult Addkhat(KhatModel p)
        //{
        //    long i = _khat.AddKhat(p);

        //    _logger.LogInformation("add khat {0}", i);
        //    return Ok(i);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Deletekhat([FromRoute] long id)
        //{
        //    long d = _khat.DeletKhat(id);

        //    _logger.LogInformation(" Delete khat {0}", d);
        //    return Ok(d);
        //}

        ///////////////////////////////////////////////////
       
    }
}
