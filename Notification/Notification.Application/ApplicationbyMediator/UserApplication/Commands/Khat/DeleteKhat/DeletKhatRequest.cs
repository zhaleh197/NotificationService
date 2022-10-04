using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.DeleteKhat
{
    public class DeletKhatRequest: IRequest<DeleteKhatResponse>//
    {
        public long idkhat { get; set; }
        public long idUser { get; set; }
    } 
}
