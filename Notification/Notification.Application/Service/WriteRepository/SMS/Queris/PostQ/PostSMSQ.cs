using Microsoft.EntityFrameworkCore;
using Notification.Application.Interface.Context;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.SMS.Queris.PostQ
{
    public class PostSMSQ : IPostSMSQ
    {
        private readonly IDatabaseContext _context;
        public PostSMSQ(IDatabaseContext context)
        {
            _context = context;
        }
        //
        public int CalcuateOperator(string phone)
        {
            string first= phone.Substring(0, 1);
            string pishshomare = "";
            if (first=="0")
                pishshomare = phone.Substring(1, 3);
            else
                pishshomare = phone.Substring(0, 2);

            var op= _context.Pishshomareh.Where(p => p.Pishshomare == pishshomare).FirstOrDefault();
            if (op != null)
                return op.idOperator;
            else return 1;
        }


        public List<double> CalculatenumberSmSandPricekhososi(long khatersal, string text)
        {

            var khototUSer = _context.KhototUsers.Include(h => h.SarKhat).Where(i => i.KhatNumber== khatersal).FirstOrDefault();
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
        public List<double> CalculatenumberSmSandPriceomomi(long khatersal, string text,long userid )
        {

            var khototUSer = _context.PublicKhotots.Include(h => h.SarKhat).Where(i => i.LineNumber == khatersal).FirstOrDefault();
            var user = _context.Users.Include(s => s.PackageTariff).Where(q => q.IdUser == userid).FirstOrDefault();
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
           else if (text.Any(c => c >= 0x20 && c <= 0x7E))
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

        public List<long> PostUserSMSinQ(RequestQeueSMSmodel request)
        {
            var khototUSer = _context.KhototUsers.Include(h => h.SarKhat).Where(i => i.IdUser == request.IdUser).FirstOrDefault();
            if (khototUSer != null)
            {

                var user = _context.Users.Include(r => r.USerType).Where(u => u.IdUser == request.IdUser).FirstOrDefault();
                double pricwithoutOperator = 0;
                //if (request.CountSms == null || request.Price == null)
                //{
                //List<double> c = CalculatenumberSmSandPricekhososi(khototUSer.Id, request.txt);
                //edit 1401/06/29  نمیدانم چرا خط را نفرستاده ام و ای دی را فرستاده ام. 
                List<double> c = CalculatenumberSmSandPricekhososi(khototUSer.KhatNumber, request.txt);
                int LenghSMS = (int)c[0];
                // request.CountSms = LenghSMS;
                pricwithoutOperator = c[1];
                // request.Price = pricwithoutOperator;
                //}


                // اینجا محاسبه هزینه کل ارسال شده گان نساز نیست. محاسبه هزینه ی تک تک فرستنده گان کافی ست.
                List<long> re = new List<long>();
                foreach (var ito in request.to)
                {

                    //محاسبه هزینه با اپراتور
                    int idoper = CalcuateOperator(ito);
                    if (idoper == 1)//hamrahaval
                        pricwithoutOperator *= khototUSer.SarKhat.HamrahAvalZarib;
                    else if (idoper == 2)//irancel
                        pricwithoutOperator *= khototUSer.SarKhat.IranselZarib;
                    else //if(idoper==3) Raytel
                        pricwithoutOperator *= khototUSer.SarKhat.RaytelZarib;
                    //request.Price = pricwithoutOperator;



                    QeueofSMS smsq = new QeueofSMS()
                    {
                        DateofLimitet = request.DateofLimitet.ToString(),
                        DateOfsend = request.DateOfsend,
                        IdUser = request.IdUser,
                        PeriodSendly = request.periodSendly,
                        TimeOfsend = request.TimeOfsend,
                        txt = request.txt,
                        TypeofResiver = request.TypeofResiver,
                        to = ito,
                        CountSms = LenghSMS,
                        Price = pricwithoutOperator,
                        //IdKhatSend =request.IdKhatSend,
                        KhatSend = request.KhatSend,
                        IdTypeSMS = request.IdTypeSMS,
                    };
                    var t = _context.QeueofSMs.Add(smsq);
                   // _context.SaveChangesAsync();
                    _context.SaveChanges();
                   // _context.SaveChangesAsync();
                    re.Add(t.Entity.Id);
                }
                return re;
            }
            else
            {

               var khototUSer2 = _context.PublicKhotots.Include(h => h.SarKhat).Where(i => i.LineNumber == request.KhatSend).FirstOrDefault();
                var user = _context.Users.Include(r => r.USerType).Where(u => u.IdUser == request.IdUser).FirstOrDefault();
                double pricwithoutOperator = 0;
                //if (request.CountSms == null || request.Price == null)
                //{
                List<double> c = CalculatenumberSmSandPriceomomi(khototUSer2.LineNumber, request.txt,user.IdUser);
                int LenghSMS = (int)c[0];
                // request.CountSms = LenghSMS;
                pricwithoutOperator = c[1];
                // request.Price = pricwithoutOperator;
                //}


                // اینجا محاسبه هزینه کل ارسال شده گان نساز نیست. محاسبه هزینه ی تک تک فرستنده گان کافی ست.
                List<long> re = new List<long>();
                foreach (var ito in request.to)
                {

                    //محاسبه هزینه با اپراتور
                    int idoper = CalcuateOperator(ito);
                    if (idoper == 1)//hamrahaval
                        pricwithoutOperator *= khototUSer2.SarKhat.HamrahAvalZarib;
                    else if (idoper == 2)//irancel
                        pricwithoutOperator *= khototUSer2.SarKhat.IranselZarib;
                    else //if(idoper==3) Raytel
                        pricwithoutOperator *= khototUSer2.SarKhat.RaytelZarib;
                    //request.Price = pricwithoutOperator;



                    QeueofSMS smsq = new QeueofSMS()
                    {
                        DateofLimitet = request.DateofLimitet.ToString(),
                        DateOfsend = request.DateOfsend,
                        IdUser = request.IdUser,
                        PeriodSendly = request.periodSendly,
                        TimeOfsend = request.TimeOfsend,
                        txt = request.txt,
                        TypeofResiver = request.TypeofResiver,
                        to = ito,
                        CountSms = LenghSMS,
                        Price = pricwithoutOperator,
                        //IdKhatSend =request.IdKhatSend,
                        KhatSend = request.KhatSend,
                        IdTypeSMS = request.IdTypeSMS,
                    };
                    var t = _context.QeueofSMs.Add(smsq);
                   // _context.SaveChangesAsync();
                    _context.SaveChanges();
                    _context.Entry(smsq); 
                    _context.Entry<QeueofSMS>(smsq).Reload();
                    // _context.SaveChangesAsync();
                    re.Add(t.Entity.Id);
                }
                return re;


            }
        }
    }
}
