using Notification.Application.ApplicationbyMediator.UserApplication.Commands;
using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.WriteModels.SMS.Common.Khat;
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

        //14010606
        public string Gettypeofuser(long request);
        public List<KhototUser> GetKhototUser(long request);
        // public IQueryable<KhototUser> GetKhototUser(long request);
        public string GetRoleofuser(long request);
        public long EditUSer(Users user);
        public long EditPrice(long userid, long newprice);
        public long EditPriceandMessageandpackage(long userid, long oldprice,long price);
        

    }
}
