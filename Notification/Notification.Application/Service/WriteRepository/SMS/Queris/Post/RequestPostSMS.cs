
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.Queris.Post
{
    public class RequestPostSMS
    {

        //newest
        public class RequestSendSMS
        {
            public long IdUser { get; set; }
            public List<string> Resiver { get; set; }
            public string Body { get; set; } 
            public string PeriodSendly { get; set; } = "Once";// none-diaily- hourly- mounthly- yearly
                                                              // public int IdKhatSend { get; set; }
            public long IdTypeSMS { get; set; }// for Periority
            public string? DateOfsend { get; set; }//if null , send Now.
            public string? TimeOfsend { get; set; }//if null , send Now.

            public string? DateofLimitet { get; set; }//if null, a day after Now. thas logicsal.
             
            public long KhatSend { get; set; }
           // public long IdKhatSend { get; set; }
          //  public int TypeofResiver { get; set; }//0 =number . 1 = Userid 
            public bool TypeofResiver { get; set; }//0 =number . 1 = Userid 

            public DateTime DateSended { get; set; }
            public DateTime DateDelivered { get; set; }
            public int Deliverd { get; set; }
            public string? SendStatus { get; set; }

            //خودمان محاسبه میکنیم

            // public int CountSms { get; set; }
            //تعداد پیام= تعداد کاراکتر/ تعداد کاراکترها برای یک پیام فارسی یا انگلیسی  
            // public double Price { get; set; }// maybe several sms. so Sum of SMS.
            //تعداد پیام * تعرفه هر پیام = هزینه ارسال 
            //if once = it is == datesend or null.  

            //
        }


        //public class ResponceSendSMS
        //{
        //    public int CountSms { get; set; }
        //    //تعداد پیام= تعداد کاراکتر/ تعداد کاراکترها برای یک پیام فارسی یا انگلیسی 
        //    //تعداد پیام * تعرفه هر پیام = هزینه ارسال
        //    public long PriceKoli { get; set; }// maybe several sms. so Sum of SMS.
        //    public DateTime DateSended { get; set; }
        //    public DateTime DateDelivered { get; set; }
        //    public int Deliverd { get; set; }
        //    public string? SendStatus { get; set; }
        //}
        //public class RequestSMSUser
        //{
        //    public virtual long IdUser { get; set; }
        //    public string Resiver { get; set; }
        //    public string Body { get; set; }
        //    public DateTime DateSend { get; set; }//kavenegar
        //    public int Delivered { get; set; }//kavenegar
        //    public DateTime DateDelivere { get; set; }//kavenegar
        //    //public DateTime DateSend { get; set; }
        //    //public DateTime DateDelivere { get; set; }
        //    public string Status { get; set; }
        //}
        //public class RequestQeueSMSUser
        //{
        //    public virtual long IdSMS { get; set; }
        //    public DateTime DateSendStart { get; set; }
        //    public int Periority { get; set; }//high/low/mediom
        //    public string Type { get; set; }//??user/phone

        //   // public string Resiver { get; set; }
        //    public List<string> Resiver { get; set; }
        //    public DateTime DateSend { get; set; }
        //    public DateTime DateDelivere { get; set; }
        //    public string SendStatus { get; set; }


        //}


    }
}
