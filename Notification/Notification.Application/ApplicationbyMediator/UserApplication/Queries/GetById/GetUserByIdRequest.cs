using MediatR;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Queries.GetById
{
    public class GetUserByIdRequest: IRequest<SMSUser>
    {
        public long IdUser { get; set; }
    }
}
