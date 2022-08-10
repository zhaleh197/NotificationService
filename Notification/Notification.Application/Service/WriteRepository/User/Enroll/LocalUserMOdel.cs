using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Enroll
{
    public class LocalUserMOdel
    {
        public long IdUser { get; set; }

        public long IdUsertype  { get; set; }

        public long IdPackagetariffSMS { get; set; }
        public DateTime DeadlinePackage { get; set; }

        public long Idprojects { get; set; }
    }
}
