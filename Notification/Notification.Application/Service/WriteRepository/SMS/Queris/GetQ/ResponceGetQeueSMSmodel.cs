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
        public bool TypeofResiver { get; set; }//0 =number . 1 = Userid
        // public DateOnly dateOfsend { get; set; }
        public DateTime dateOfsend { get; set; }//only date
       // public TimeSpan timeOfsend { get; set; }
        public DateTime timeOfsend { get; set; }
        public DateTime dateofLimitet { get; set; }
        //public string dateOfsend { get; set; } = DateTime.Now.ToString();
        //public string timeOfsend { get; set; }
        //public string dateofLimitet { get; set; }
        public string periority { get; set; }//hidh-normal
        public string periodSendly { get; set; }// none-diaily- hourly- mounthly- yearly

    }
}
