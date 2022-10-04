using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Kafka
{
    public class OrderRequest
    {
        //public long Id { get; set; }

        //public string topic { get; set; }

        public long Id { get; set; }
        public string topic { get; set; }

        //public string to { get; set; }
        //public string txt { get; set; }
        //public string sender { get; set; }
    }
    public class OrderRequestFull
    {
        //public long Id { get; set; }

        //public string topic { get; set; }

        public long Id { get; set; }
        public string topic { get; set; }
        public string to { get; set; }
        public string txt { get; set; }
        public string sender { get; set; }
    }
}
