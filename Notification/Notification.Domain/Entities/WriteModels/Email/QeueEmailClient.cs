using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Email
{
    public class QeueEmailClient
    {
        [Key]
        public long Id { get; set; }
        public long IdClient { get; set; }
        public string Resiver { get; set; }
      
        public string Title { get; set; } 
        public string Body { get; set; }
        public DateTime DateSendStart { get; set; }
        public string Periority { get; set; }
        public string Type { get; set; }

    }
}
