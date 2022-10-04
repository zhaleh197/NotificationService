using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Kat
{
    public class KhatModelGet
    {
        public  long Id { get; set; }
        public  long IdUser { get; set; }
       
        public long LineNumber { get; set; }
        public int IdSarKhat { get; set; }//link be sarkhat ha
        public bool Statuse { get; set; }//Active-notAvtive
        public bool Type { get; set; }//0==Omoomi . 1= Khososi 
       
        public DateTime DedlineKhat { get; set; }// = insert time(NOW) year+1. baraye omoomi =null - baraye khososi = yek sal.
                                                 // in code: if(type=0) send.  elseif (type== 1){ if (dellinekhat>now) Send.}

    }
    public class KhatModel
    {
        public long IdUser { get; set; }
        public long IdTransaction { get; set; }
        public long LineNumber { get; set; }
        public int IdSarKhat { get; set; }//link be sarkhat ha
        public bool Statuse { get; set; }//Active-notAvtive
        public bool Type { get; set; }//0==Omoomi . 1= Khososi 
                                      //  public  long Id { get; set; }
        public DateTime DedlineKhat { get; set; }// = insert time(NOW) year+1. baraye omoomi =null - baraye khososi = yek sal.
                                                 // in code: if(type=0) send.  elseif (type== 1){ if (dellinekhat>now) Send.}

    }
    
    public class PriceKhatkhososiREquest
    {  
        public int LengthofNumber { get; set; }
        public string SarKhat { get; set; }//link be sarkhat ha                                          // in code: if(type=0) send.  elseif (type== 1){ if (dellinekhat>now) Send.}

    }


    public class PublicKhatModelGet
    {
        public long Id { get; set; }

        public int LengthofNumber { get; set; }// ham sarkhat ham khat= 300087546532

        public long LineNumber { get; set; }// ham sarkhat ham khat= 300087546532

        public int IdSarKhat { get; set; }//link be sarkhat ha
        public bool Statuse { get; set; }//Active-notAvtive 
    }

    public class KhososiKhatModelGet
    {
        public long Id { get; set; }

        public int LengthofNumber { get; set; }// ham sarkhat ham khat= 300087546532 
        public int IdSarKhat { get; set; }//link be sarkhat ha
        public long Price { get; set; }//1 acrite-0 noonActive
    } 

    


}
