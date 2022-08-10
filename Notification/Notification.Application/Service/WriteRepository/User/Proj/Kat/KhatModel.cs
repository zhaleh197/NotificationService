using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Proj.Kat
{
    public class KhatModel
    {
        public virtual long IdSarKhat { get; set; }
       
        public string LineNumber { get; set; }
        public bool Statuse { get; set; }//Active-notAvtive
        public  long IdProjects { get; set; }
        public  long Id { get; set; }
    }
}
