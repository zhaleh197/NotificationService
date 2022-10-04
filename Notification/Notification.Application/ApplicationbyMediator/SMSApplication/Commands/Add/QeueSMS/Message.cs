using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS
{
    public class Message
    {
        public string txt { get; set; }
        public List<string> to { get; set; }
        public bool TypeofResiver { get; set; }//0 =number . 1 = Userid
        public long IdTypeSMS { get; set; }// for Periority
        //public long IdKhatSend { get; set; }
        //14010623
        public long KhatSend { get; set; }
    }
}
