using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.SMS.Queris.GetQ
{
    public class ResponceGetQeueSMSmodel
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string txt { get; set; }
        public string to { get; set; }
        public bool TypeofResier { get; set; }//0 =number . 1 = Userid
        // public DateOnly datveOfsend { get; set; }
        public string DateOfsend { get; set; }//only date
       // public TimeSpan timeOfsend { get; set; }
        public string TimeOfsend { get; set; }
        public string DateofLimitet { get; set; }
        //public string dateOfsend { get; set; } = DateTime.Now.ToString();
        //public string timeOfsend { get; set; }
        //public string dateofLimitet { get; set; }



       // public int Periority { get; set; }//hidh-normal
        public string PeriodSendly { get; set; }// none-diaily- hourly- mounthly- yearly

        public int CountSms { get; set; }
        //تعداد پیام= تعداد کاراکتر/ تعداد کاراکترها برای یک پیام فارسی یا انگلیسی  
        public double Price { get; set; }// maybe several sms. so Sum of SMS.
                                         //تعداد پیام * تعرفه هر پیام = هزینه ارسال 
                                         //if once = it is == datesend or null.  
        
         public long IdTypeSMS { get; set; }//for periority
                                //
         public long KhatSend { get; set; }
        //public long IdKhatSend { get; set; }

    }
}
