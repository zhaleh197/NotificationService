using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.Queris.Get
{
    //public class ResultGetClientSMS
    //{
    //    public long Id { get; set; }
    //    public long IdClient { get; set; }
    //    public string Resiver { get; set; }

    //    public string Body { get; set; }
    //    public DateTime DateSend { get; set; }
    //    public DateTime DateDelivere { get; set; }
    //    public string Status { get; set; }
    //}
    public class ResultGetUserSMS
    {
        public long Id { get; set; }
        public long IdUser { get; set; }

        public string Body { get; set; }

        public string Status { get; set; }


        public int CountSms { get; set; }
        //تعداد پیام= تعداد کاراکتر/ تعداد کاراکترها برای یک پیام فارسی یا انگلیسی 

        public double Price { get; set; }// maybe several sms. so Sum of SMS.
                                         //تعداد پیام * تعرفه هر پیام = هزینه ارسال


        //if once = it is == datesend or null.

        public virtual long IdTypeSMS { get; set; }


        public string? DateOfsend { get; set; }//if null , send Now.
        public string? TimeOfsend { get; set; }//if null , send Now.

        public string? DateofLimitet { get; set; }//if null, a day after Now. thas logicsal.


        public string PeriodSendly { get; set; } = "Once";// none-diaily- hourly- mounthly- yearly
                                                          // public int IdKhatSend { get; set; }

        //public   long IdKhatSend { get; set; }

        public long KhatSend { get; set; }

        public List<ResiverClas> Resivers { get; set; }



    }
    public class ResiverClas
    {
        public string Resiver { get; set; }
        //new 14010606
        public int TypeofResiver { get; set; }//0 =number . 1 = Userid
        public DateTime DateSended { get; set; }
        public DateTime DateDelivered { get; set; }
        public int Deliverd { get; set; }

        public string? SendStatus { get; set; }
    }

    //public class ResultGetQeueClientSMS
    //{
    //    public long Id { get; set; }
    //    public long IdClient { get; set; }
    //    public string Resiver { get; set; }
    //    public string Body { get; set; }
    //    public DateTime DateSendStart { get; set; }
    //    public string Periority { get; set; }
    //    public string Type { get; set; }
    //}


    //    public class ResultGetQeueUserSMS
    //{
    //    public long Id { get; set; }
    //    public long IdUser { get; set; }
    //   // public string Resiver { get; set; }
    //    public List<string> Resiver { get; set; }
    //    public string Body { get; set; }
    //    public DateTime DateSendStart { get; set; }
    //    public int Periority { get; set; }
    //    public string Type { get; set; }
    //}



}
