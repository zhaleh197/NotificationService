using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.DeleteDoc
{
    public class DeleteDocRequest:IRequest<DeleteDocResponse>//
    {
        public long idDoc { get; set; }
    }
}
