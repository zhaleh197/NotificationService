using MediatR;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.User.Enroll;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, long>
    {
        private readonly ILocalUser _localUser;
        public AddUserHandler(ILocalUser localUser)
        {
            _localUser = localUser;   
        }

        public Task<long> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<long> Handle(AddUserCommand request, CancellationToken cancellationToken)
        //{
        //    //var command = _localUser.UserEnroll(new LocalUserMOdel { IdUser = request.IdUser, DeadlinePackage = request.DeadlinePackage, IdPackagetariffSMS = request.IdPackagetariffSMS, Idprojects = request.Idprojects, IdUsertype = request.IdUsertype });

        //    //return _localUser.UserEnroll2(request.User);

        //    //if (command > 0)
        //    //{
        //    //    //send email to Admin
        //    //    await _mediator.Publish(new EmailNotification("admin@site.com", "User {IdUser} Was  Enrolled.", "Notification of Enroll User.", request.IdUser));

        //    //}

        //    //await _db.SaveChangesAsync(cancellationToken);

        //    //await _channel.AddToChannelAsync(new UserAdded { IdUSer = request.IdUser }, cancellationToken);



        //    //return await Task.FromResult(new EnrollUserResponse { Id = command });
        //}
    }
}
