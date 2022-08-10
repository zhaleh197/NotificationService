using Notification.Application.ApplicationbyMediator.UserApplication.Commands;
using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Enroll
{
    public interface ILocalUser
    {
        public long UserEnroll(LocalUserMOdel req);
        //public long UserEnroll2(userCommand req);
        public long DeleteUser(long request, CancellationToken cancellationToken = default);
        public Users GetuserbyIduser(long request, CancellationToken cancellationToken = default);
    }
}
