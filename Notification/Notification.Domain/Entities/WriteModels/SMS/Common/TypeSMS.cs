using Notification.Domain.Entities.WriteModels.SMS.SMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.SMS.Common
{
    public class TypeSMS
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } 
        public int Periority { get; set; }//hidh-normal
        public bool Confirm { get; set; }
        public virtual ICollection<SMessageS>? SMessageS{ get; set; }

    }
}
