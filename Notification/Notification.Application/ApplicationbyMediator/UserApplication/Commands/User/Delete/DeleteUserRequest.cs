using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Delete
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>//
    {
        public long IdUser { get; set; }
    }
}
