using Notification.Application.Service.SMS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.background
{

    public interface IExecuteBackground
    {
        public void Execute(SMSSendRequest2 request);

        //_sMSService.SMSF(new SMSSendRequest2 { to = request.Resiver, txt = request.Body });


        //edit status in sms table to Sended.



        //delet in Qeuesms  table 


    }
}
