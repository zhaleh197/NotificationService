using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.SMS.Common
{
    public class UserSarkhat
    {
        [Key]
        public long Id { get; set; }
        public long IdUser { get; set; }
        public long IdSarkhat { get; set; }
    }
}
