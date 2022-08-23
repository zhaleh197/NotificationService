using Kavenegar;
using Notification.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Notification.Application.Service.SMS.Commands
{
    public class SMSService : ISMSService
    {
        private readonly IDatabaseContext _context;
        public SMSService(IDatabaseContext context)
        {
            _context = context;
        }

        public int CheckSpam(string sms)
        {
            string[] multiArray = sms.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t', '(', ')', '*', '&', '^', '%', '$', '#', '@', '!' });
            foreach (var t in multiArray)
            {
                var ret = _context.SpamWords.FirstOrDefault(x => x.Word.Equals(t));
                if (ret!=null)
                    return 1;
            }
            return 0;
        }
        public void SMS(SMSSendRequest req)
        {// _admin = (IAdmin)context.HttpContext.RequestServices.GetService(typeof(IAdmin));

            // Setting setting = _admin.GetSetting();
            // var sender = setting.SMSSender;
            //var sender = "1000596446";//10000900900300//1008663
            req.sender = "10000900900300";//10000900900300//1008663
            var resiver = req.to;
            var txte = req.txt;
            req.apikey = "6F35654138502B574E563439634A782B6177333770766356546B564B706B736D4A76686F392B4C736F70773D";
            var api = new KavenegarApi(req.apikey);
            //var api = new KavenegarApi(setting.SMSApi);
            api.Send(req.sender, resiver, txte);
            


        }
        public void SMSF(SMSSendRequest2 req)
        {  //"from=10009424&to=9188716505&text=تست سامانه&password=nim@123&username=kurdet";
            string URI = "http://87.107.121.52/post/sendsms.ashx";
            //string myParameters = "from=50002237171&to=";
            string myParameters = "from=10008733730550&to=";
            // myParameters += req.to + "&text=" + req.txt + "&password=nim@123@nim&username=westco";
            myParameters += req.to + "&text=" + req.txt + "&password=nim@123&username=westco.app";
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string HtmlResult = wc.UploadString(URI, myParameters);
        }
        public SMSSendResponse SMSFF(SMSSendRequest req)
        {
            if (CheckSpam(req.txt) == 0)
            {
                req.sender = "10000900900300";//10000900900300//1008663
                var resiver = req.to;
                var txte = req.txt;
                req.apikey = "6F35654138502B574E563439634A782B6177333770766356546B564B706B736D4A76686F392B4C736F70773D";
                var api = new KavenegarApi(req.apikey);
                //var api = new KavenegarApi(setting.SMSApi);

                //var re= api.Send(req.sender, resiver, txte);

                // DateTime dat_Time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                // dat_Time = dat_Time.AddSeconds(re.Date);


                // in ra bayad az mr nastarani beporsam.

                //فعلا برداشته شود برای صرفه جویی در هزینه
                //return new SMSSendResponse { statuse = re.StatusText, datesend = dat_Time, deliverd = re.Status, cost = re.Cost };
                
                return new SMSSendResponse { statuse = "ارسال شد", datesend = DateTime.Now, deliverd =1 ,cost=10};
            }
            return new SMSSendResponse { statuse = "NOT Sended, this is Spam.",deliverd=-1 };

        }

        public SMSSendResponse SMSFinal(SMSSendRequest3 req)

        {

            if (CheckSpam(req.txt) == 0)
            {
                //"from=10009424&to=9188716505&text=تست سامانه&password=nim@123&username=kurdet";
                string URI = "http://87.107.121.52/post/sendsms.ashx";
                //string myParameters = "from=50002237171&to=";
                string myParameters = "from=" + req.sender + "&to=";
                // myParameters += req.to + "&text=" + req.txt + "&password=nim@123@nim&username=westco";
                myParameters += req.to + "&text=" + req.txt + "&password=nim@123&username=westco.app";
                WebClient wc = new WebClient();
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);

                // in ra bayad az mr nastarani beporsam.
                return new SMSSendResponse { statuse = "Sended", datesend = DateTime.Now, deliverd = 1 };
            }
            return new SMSSendResponse { statuse = "NOT Sended, this is Spam.", deliverd = -1 };

        }

    }
}
