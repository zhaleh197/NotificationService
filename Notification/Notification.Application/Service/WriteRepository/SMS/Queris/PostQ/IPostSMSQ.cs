using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.SMS.Queris.PostQ
{
    
    public interface IPostSMSQ
    {
        public List<long> PostUserSMSinQ(RequestQeueSMSmodel request);
    }
}
