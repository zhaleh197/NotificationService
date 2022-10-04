using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.SMS.Queris.PostQ
{
    public class RequestQeueSMSmodel
    {
        public long IdUser { get; set; }
        public string txt { get; set; }
        public List<string> to { get; set; }
        public bool TypeofResiver { get; set; }//0 =number . 1 = Userid
        //public DateOnly dateOfsend { get; set; }
        public string DateOfsend { get; set; }
        //public DateTime dateOfsend { get; set; }

        //public DateTime timeOfsend { get; set; }
        public string TimeOfsend { get; set; }
        //public TimeSpan timeOfsend { get; set; }
        public DateTime DateofLimitet { get; set; }
        //public string dateOfsend { get; set; }
        //public string timeOfsend { get; set; }
        //public string dateofLimitet { get; set; }

        public int periority { get; set; }//hidh-normal
        public string periodSendly { get; set; }// none-diaily- hourly- mounthly- yearly

        //خودمان محاسبه میکنیم

        // public int CountSms { get; set; }
        //تعداد پیام= تعداد کاراکتر/ تعداد کاراکترها برای یک پیام فارسی یا انگلیسی  
        // public double Price { get; set; }// maybe several sms. so Sum of SMS.
        //تعداد پیام * تعرفه هر پیام = هزینه ارسال 
        //if once = it is == datesend or null.  

        //


        public long IdTypeSMS { get; set; }//for periority //


       // public  long IdKhatSend { get; set; }
        public long  KhatSend { get; set; }

    }
}
