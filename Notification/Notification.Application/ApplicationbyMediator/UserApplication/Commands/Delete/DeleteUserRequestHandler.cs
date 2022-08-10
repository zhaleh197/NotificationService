using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.User.Enroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Delete
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly ILocalUser _localUser;
        private readonly ChannelQueue<UserDeleted> _channel;
        public DeleteUserRequestHandler(ILocalUser localUser
            , ChannelQueue<UserDeleted> channel)
        {
            _channel = channel;
            _localUser = localUser;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken = default)
        {


            var command = _localUser.DeleteUser(request.IdUser);
            //if (command > 0)
            //{
            //    //send email to Admin
            //    await _mediator.Publish(new EmailNotification("admin@site.com", "User {IdUser} Was  Enrolled.", "Notification of Enroll User.", request.IdUser));

            //}

            //await _db.SaveChangesAsync(cancellationToken);

            await _channel.AddToChannelAsync(new UserDeleted { IdUSer = request.IdUser }, cancellationToken);
            // return await Task.FromResult(new EnrollUserResponse { Id= request.IdUser  });
            return new DeleteUserResponse { Id = request.IdUser };

        }
    }

}
