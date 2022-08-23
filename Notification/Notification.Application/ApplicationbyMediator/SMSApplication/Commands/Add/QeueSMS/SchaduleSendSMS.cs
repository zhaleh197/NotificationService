using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS
{
    public class SchaduleSendSMS
    {
        //public DateOnly dateOfsend { get; set; }
       // public DateTime dateOfsend { get; set; }//but only date
        public string dateOfsend { get; set; }//but only date
        //public TimeSpan timeOfsend { get; set; }
        //public DateTime timeOfsend { get; set; }//but only time
        public string timeOfsend { get; set; }//but only time
        public DateTime dateofLimitet { get; set; }
        //public string dateOfsend { get; set; }
        //public string timeOfsend { get; set; }

        //public string dateofLimitet { get; set; }
        public  int periority  { get; set; }//hidh-normal
        public string periodSendly { get; set; }// none-diaily- hourly- mounthly- yearly
    }
}
    