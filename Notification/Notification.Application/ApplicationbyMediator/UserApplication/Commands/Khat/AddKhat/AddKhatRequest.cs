using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.AddKhat
{
    public class AddKhatRequest : IRequest<AddKhatResponse>
    {
        public long IdUser { get; set; }
        public long IdTransaction { get; set; }
        public long LineNumber { get; set; }
        public int IdSarKhat { get; set; }//link be sarkhat ha
        public bool Statuse { get; set; }//Active-notAvtive
        public bool Type { get; set; }//0==Omoomi . 1= Khososi 
                                      //  public  long Id { get; set; }
        public DateTime DedlineKhat { get; set; }// = insert time(NOW) year+1. baraye omoomi =null - baraye khososi = yek sal.

    }
}
