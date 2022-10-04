using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification;
//using Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Delete;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.AddDoc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.DeleteDoc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Transaction.AddTrans;
using Notification.Application.ApplicationbyMediator.UserApplication.Queries.GetById;
using System.Security.Claims;
//using Notification.Application.Service.User.Enroll;

namespace NotificationAPICQRS.Controllers
{


    [Route("api/[controller]/[action]")]
    [ApiController]
   // [Authorize]
    public class UserController : Controller
    {

        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
           _mediator = mediator;
        }

        //[HttpPost]
        //public async Task<IActionResult> Enroll(userCommand command)
        //{
        //    var re = _mediator.Send(new AddUserCommand(command));
        //    //var re = await _mediator.Send(new EnrollUserRequest { IdUser=command.IdUser,IdUsertype=command.IdUsertype,
        //    //DeadlinePackage = command.DeadlinePackage,Idprojects=command.Idprojects,IdPackagetariffSMS=command.IdPackagetariffSMS});


        //    //send email to Admin

        //    if (re != null)
        //    {
        //      //  await _mediator.Publish(new EmailNotification("admin@site.com", "User {IdUser} Was  Enrolled.", "Notification of Enroll User."));
        //        return Ok(command);
        //    }
        //    return BadRequest();
        //}

////////////////////USER :Enroll ang GetbyID
        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollUserRequest command)
        {
            //var userId = User?.FindFirst(ClaimTypes.NameIdentifier);
            //var userphone = User?.FindFirst(ClaimTypes.MobilePhone);
            //command.Phone= userphone.Value;

            var re = _mediator.Send(command);
            //var re = await _mediator.Send(new EnrollUserRequest { IdUser=command.IdUser,IdUsertype=command.IdUsertype,
            //DeadlinePackage = command.DeadlinePackage,Idprojects=command.Idprojects,IdPackagetariffSMS=command.IdPackagetariffSMS});


            //send email to Admin
            string emil= "zhaleh.manbari@gmail.com";// for whet you wanna send an email for Admin
            if (re != null)
            {
                await _mediator.Publish(new EmailNotification(emil, "User {IdUser} Was  Enrolled.", "Notification of Enroll User."));
                return Ok(command);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserByIdRequest model, CancellationToken cancellationToken)
        {
            var query = await _mediator.Send(model, cancellationToken);

            return Ok(query);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await _mediator.Send(new GetAllPersonQueryModel()));
        //}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserRequest model, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(model, cancellationToken));
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, EditPersonCommandModel command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(await _mediator.Send(command));
        //}


        //////////////////////////////////
        ///
        //USER: Documents
        [HttpPost]
        public async Task<IActionResult> AddDoc(AddDocRequest command)
        {
            var re =await _mediator.Send(command);
            if (re != null)
            {
                return Ok(command);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(AddTransactionRequest command)
        {
            var re = await _mediator.Send(command);
            if (re != null)
            {
                return Ok(command);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDoc([FromQuery] DeleteDocRequest model, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(model, cancellationToken));
        }


        //
    }
}
