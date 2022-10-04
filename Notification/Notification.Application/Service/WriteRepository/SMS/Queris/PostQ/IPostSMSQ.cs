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
        public List<double> CalculatenumberSmSandPricekhososi(long idkhatersal, string text);
        //public List<double> CalculatenumberSmSandPrice(long idkhatersal, string text);
        public List<double> CalculatenumberSmSandPriceomomi(long khatersal, string text, long userid);
        public int CalcuateOperator(string phone);

    }
}
