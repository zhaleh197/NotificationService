using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.Common.Events.UserEvent;
using Notification.Application.Service.User.Enroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add
{
    public class EnrollUserRequestHandler : IRequestHandler<EnrollUserRequest, EnrollUserResponse>
    {
        private readonly ILocalUser _localUser;
        private readonly ChannelQueue<UserAdded> _channel;
        public EnrollUserRequestHandler(ILocalUser localUser
            , ChannelQueue<UserAdded> channel)
        {
            _channel = channel;
            _localUser = localUser;
        }
        public async Task<EnrollUserResponse> Handle(EnrollUserRequest request, CancellationToken cancellationToken=default)
        { 

            var command = _localUser.UserEnroll(
                new LocalUserMOdel {
                    IdUser = request.IdUser,
                    Phone=request.Phone, 
                    CreditFinance=request.CreditFinance,
                    CridetMeaasage=request.CridetMeaasage,
                    IdRole=request.IdRole,
                    IdUsertype=request.IdUsertype,
                   
                    });

            //if (command > 0)
            //{
            //    //send email to Admin
            //    await _mediator.Publish(new EmailNotification("admin@site.com", "User {IdUser} Was  Enrolled.", "Notification of Enroll User.", request.IdUser));

            //}

            //await _db.SaveChangesAsync(cancellationToken);

            await _channel.AddToChannelAsync(new UserAdded { IdUSer =     request.IdUser }, cancellationToken);
            // return await Task.FromResult(new EnrollUserResponse { Id= request.IdUser  });
            return new EnrollUserResponse { Id = request.IdUser };

        }
    }



}
