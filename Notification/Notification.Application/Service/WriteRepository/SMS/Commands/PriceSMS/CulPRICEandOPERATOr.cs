using Microsoft.EntityFrameworkCore;
using Notification.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.SMS.Commands.PriceSMS
{
    public class CulPRICEandOPERATOr
    {
        private readonly IDatabaseContext _context;
        public CulPRICEandOPERATOr(IDatabaseContext context)
        {
            _context = context;
        }

        public int CalcuateOperator(string phone)
        {
            string first = phone.Substring(0, 1);
            string pishshomare = "";
            if (first == "0")
                pishshomare = phone.Substring(1, 3);
            else
                pishshomare = phone.Substring(0, 2);

            var op = _context.Pishshomareh.Where(p => p.Pishshomare == pishshomare).FirstOrDefault();
            if (op != null)
                return op.idOperator;
            else return 1;
        }


        public List<double> CalculatenumberSmSandPrice(long idkhatersal, string text)
        {

            var khototUSer = _context.KhototUsers.Include(h => h.SarKhat).Where(i => i.Id == idkhatersal).FirstOrDefault();
            var user = _context.Users.Include(s => s.PackageTariff).Where(q => q.IdUser == khototUSer.IdUser).FirstOrDefault();
            //var khototUSer = _context.KhototUsers.Include(h => h.SarKhat).Where(i=>i.Id==request.IdKhatSend).FirstOrDefault();

            // string text = request.Body; 
            string result = "";
            //if (text.Any(c => c >= 0xFB50 && c <= 0xFEFC))
            //{
            //    result += "Arabic";
            //}
            //if (text.Any(c => c >= 0x0530 && c <= 0x058F))
            //{
            //    result += "Armenian";
            //}
            //if (text.Any(c => c >= 0x2000 && c <= 0xFA2D))
            //{
            //    result += "Chinese";
            //}

            if (text.Any(c => c >= 0x0600 && c <= 0x06FF))
            {
                result = "Persian";
            }
            if (text.Any(c => c >= 0x20 && c <= 0x7E))
            {
                result = "English";
            }

            //if txt is Farsi
            double tt = 0;
            int numerAllCharacter = 0;
            int numberofchar = 1;
            int numberofchar2 = 1;
            int numberofchar3 = 1;
            if (result == "Persian")
            {
                tt = tt = user.PackageTariff.ZaridTakhfifPaciTareeffe * khototUSer.SarKhat.BasePrice * khototUSer.SarKhat.PersianZarib; ;//Convert.ToInt32(resd.PackageTariff.FarsiTariff);

                numberofchar = 70;//1=70- 2=64- 3=67...
                numberofchar2 = 64;
                numberofchar3 = 67;
            }
            else //if txt is English
            {
                tt = user.PackageTariff.ZaridTakhfifPaciTareeffe * khototUSer.SarKhat.BasePrice * khototUSer.SarKhat.EnglishZarib;

                // Convert.ToInt32(resd.PackageTariff.EnglishTariff);
                numberofchar = 160;//1=160,2=146,3=153...
                numberofchar2 = 146;
                numberofchar3 = 153;
            }

            //



            numerAllCharacter = text.Count();

            int numSMS = 1;
            if (numerAllCharacter > numberofchar && numerAllCharacter <= (numberofchar + numberofchar2)) numSMS = 2;
            else if (numerAllCharacter > (numberofchar + numberofchar2) && numerAllCharacter <= (numberofchar + numberofchar2 + numberofchar3)) numSMS = 3;
            else numSMS = (numerAllCharacter / 67 + 1);//>201 


            double pri = numSMS * tt;


            return new List<double> { numSMS, pri };

        }

    }
}
