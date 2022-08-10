using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.Commands
{
    public interface ISMSService
    {
        public void SMS(SMSSendRequest req);
        public void SMSF(SMSSendRequest2 req);

        public SMSSendResponse SMSFF(SMSSendRequest req);
        public SMSSendResponse SMSFinal(SMSSendRequest3 req);

    }
}
