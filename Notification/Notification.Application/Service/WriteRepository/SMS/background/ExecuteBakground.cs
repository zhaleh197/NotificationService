using Notification.Application.Service.SMS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.background
{
    public class ExecuteBakground:IExecuteBackground
    {
        //private readonly ISMSService _sMSService;
        //public ExecuteBakground(ISMSService sMSService)
        //{ 
        //     //_sMSService = sMSService; 
        //}

        public ExecuteBakground()
        {

        }

        public void Execute(SMSSendRequest2 request)
        {
             var s = new SMSService();
             s.SMSF(new SMSSendRequest2 { to = request.to, txt = request.txt });
            Console.WriteLine("oh my god  ");

        }
            

            //edit status in sms table to Sended.



            //delet in Qeuesms  table 
        }
}
