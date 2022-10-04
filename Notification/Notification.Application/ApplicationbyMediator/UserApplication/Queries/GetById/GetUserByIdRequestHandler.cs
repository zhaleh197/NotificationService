using MediatR;

using Notification.Application.Service.ReadRepository.User;
using Notification.Domain.Entities.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Queries.GetById
{
    public class GetUserByIdRequestHandler : IRequestHandler<GetUserByIdRequest, SMSUser>
    {
        private readonly ReadSMSUser _readSMSUser;

        public GetUserByIdRequestHandler(ReadSMSUser readSMSUser)
        {
            _readSMSUser = readSMSUser;
        }

        public Task<SMSUser> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            //return _readSMSUser.GetByUSerIdAsync(request.IdUser, cancellationToken);
            return _readSMSUser.GetByUSerIdAsync(request.IdUser);
        }

         
        //public Task<SMSUser> Handle(GetUserByIdRequest request)
        //{
        //    return _readSMSUser.GetByUSerIdAsync(request.IdUser);
        //}

    }
}
