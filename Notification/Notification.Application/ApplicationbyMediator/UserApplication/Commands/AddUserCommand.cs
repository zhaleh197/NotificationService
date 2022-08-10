

using MediatR;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands
{
    public record AddUserCommand(userCommand User) :IRequest<long>;
   
}
