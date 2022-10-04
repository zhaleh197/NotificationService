using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Common.ResponceMobel
{
    public class ResponseModel<TKey>
    {
        public TKey Model { get; set; }
        public string ResponceMessage { get; set; } = "OK";
        public bool ISOK { get; set; } = true;
    }

}

