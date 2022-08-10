using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Common
{
    public class Usertype: BaseEntity<long>
    {
        //[Key]
        //public long Id { get; set; }
        public string Title { get; set; }// haghigghi / hoghooghi


        public virtual ICollection<Users> User { get; set; }


    }
}
