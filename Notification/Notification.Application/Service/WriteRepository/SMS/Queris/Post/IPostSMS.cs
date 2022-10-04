using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Notification.Application.Service.SMS.Queris.Post.RequestPostSMS;

namespace Notification.Application.Service.SMS.Queris.Post
{
    public interface IPostSMS
    {
       // public int PostUserSMS(RequestSMSUser request);
        //public long PostUserSMS(RequestSMSUser request);
        //public int PostUserSMSinQu(RequestQeueSMSUser request);
        public long PostUserSMS(RequestSendSMS request);
        public List<double> CalculatenumberSmSandPricekhososi(long idkhatersal, string text);
        public List<double> CalculatenumberSmSandPriceomomi(long idkhatersal, string text, long userid);
        public int CalcuateOperator(string phone);

    }
}
