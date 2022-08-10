using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.SMS.Queris.GetQ
{
    public interface IGetQ
    {
        public List<ResponceGetQeueSMSmodel> GetQeueUserSMS();
        public ResponceGetQeueSMSmodel GetsSMSinQbyId(long Id );
        public long DeleteSMSinQbyId(long Id);
       //public ResponceGetQeueSMSmodel UpdateSMSinQbyId(long Id,DateOnly dateESeralJadid, TimeOnly timeESeralJadid);
        public ResponceGetQeueSMSmodel UpdateSMSinQbyIdF(long Id, DateOnly dateESeralJadid, TimeSpan timeESeralJadid);
    }
}
