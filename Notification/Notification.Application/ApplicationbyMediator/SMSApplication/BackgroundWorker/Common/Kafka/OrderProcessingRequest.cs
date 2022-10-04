using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Kafka
{
    public class OrderProcessingRequest
    {
        public long Id { get; set; }
        public string statuse { get; set; }
        //public DateTime datesend { get; set; }
        public string datesend { get; set; }
        public int deliverd { get; set; }
        public int cost { get; set; }
    }
}
