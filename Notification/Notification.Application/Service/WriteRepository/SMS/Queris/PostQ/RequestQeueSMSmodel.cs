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
        public string dateOfsend { get; set; }
        //public DateTime dateOfsend { get; set; }

        //public DateTime timeOfsend { get; set; }
        public string timeOfsend { get; set; }
        //public TimeSpan timeOfsend { get; set; }
        public DateTime dateofLimitet { get; set; }
        //public string dateOfsend { get; set; }
        //public string timeOfsend { get; set; }
        //public string dateofLimitet { get; set; }

        public int periority { get; set; }//hidh-normal
        public string periodSendly { get; set; }// none-diaily- hourly- mounthly- yearly
 

    }
}
