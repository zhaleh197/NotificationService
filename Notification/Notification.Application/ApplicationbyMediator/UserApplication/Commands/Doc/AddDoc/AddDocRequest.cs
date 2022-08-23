using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.AddDoc
{
    public class AddDocRequest:IRequest<AddDocResponse>//long is response.
    {
        public long idUser { get; set; }
        public long idDocumentType { get; set; }
        public string base64imagopDoc { get; set; }
        public bool Confirmcheck { get; set; }
    }
}
