using Microsoft.EntityFrameworkCore;
using Notification.Application.Interface.Context; 
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Notification.Application.Service.SMS.Queris.Post.RequestPostSMS;

namespace Notification.Application.Service.SMS.Queris.Post
{
    public class PostSMS: IPostSMS//this is a old model. when we first add in SMS ofter that in Queu. But now we dod viversa. in POSTQ Service
    {
        private readonly IDatabaseContext _context;
        //private readonly ITaskJob<RequestQeueSMSUser> _taskJob;
       // private readonly ITaskJobs _taskJob;
        public PostSMS(IDatabaseContext context
           // ,ITaskJob<RequestQeueSMSUser> taskJob,
          //  ITaskJobs taskJob
            )
        {
            _context = context;
           // _taskJob = taskJob;
        }

        /// OLD  
        //public int PostUserSMS(RequestSMSUser request)
        //{
        //   // var r =farsi/Or englisi
        //    var r = request.Body.Count()/20;
        //    SMSUser user = new SMSUser()
        //    {
        //        IdUser = request.IdUser,
        //        Body=request.Body,
        //        Price=   r,




        //        //DateDelivere=request.DateDelivere,
        //       // DateSend=request.DateSend,


        //        //Resiver=request.Resiver,
        //       // Status=request.Status,
        //        InsertTime=DateTime.Now,
        //        IsRemoved=false,
        //        RemoveTime=null,
        //        UpdateTime=null

        //    };
        //    _context.SMSUsers.Add(user);
        //    _context.SaveChanges(); 

        //    //14040420
        //    foreach (var resiver in request.Resiver)
        //    {
        //       _context.SMS_Resivers.Add(new SMS_Resivers() { IdSMS = _context.SMSUsers.Last().Id, DateSend = request.DateSend, DateDelivere = request.DateDelivere, Resiver = resiver ,SendStatus="",});
        //        _context.SaveChanges();
        //    }
        //    //
        //    //
        //    var v = new RequestQeueSMSUser {DateSendStart=DateTime.Now,IdSMS = _context.SMSUsers.Last().Id, Periority="High",Resiver=request.Resiver,Type="phone",DateSend=DateTime.Now,SendStatus=""};
        //    PostUserSMSinQu(v);


        //    _taskJob.Qeuetask.Enqueue(v);

        //    return 1;
        //}

        public long UpdateCriditUser(RequestSendSMS request, long Iduser)
        {
            return 0;
        }

        //public int CalcuateOperator(string phone)
        //{
        //    string pishshomare = "";
        //    return  _context.Pishshomareh.Where(p => p.Pishshomare == pishshomare).FirstOrDefault().idOperator;

        //}

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


        public List<double> CalculatenumberSmSandPricekhososi(long idkhatersal, string text )
        {

            var khototUSer = _context.KhototUsers.Include(h => h.SarKhat).Where(i => i.KhatNumber== idkhatersal).FirstOrDefault();
            var user= _context.Users.Include(s => s.PackageTariff).Where(q => q.IdUser == khototUSer.IdUser).FirstOrDefault();
           //var khototUSer = _context.KhototUsers.Include(h => h.SarKhat).Where(i=>i.Id==request.IdKhatSend).FirstOrDefault();
           
            // string text = request.Body; 
            string result = "Persian";
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
                tt = tt =user.PackageTariff.ZaridTakhfifPaciTareeffe* khototUSer.SarKhat.BasePrice * khototUSer.SarKhat.PersianZarib; ;//Convert.ToInt32(resd.PackageTariff.FarsiTariff);
               
                numberofchar = 70;//1=70- 2=64- 3=67...
                numberofchar2 = 64;
                numberofchar3 = 67;
            }
            else //if txt is English
            {
                tt = user.PackageTariff.ZaridTakhfifPaciTareeffe * khototUSer.SarKhat.BasePrice * khototUSer.SarKhat.EnglishZarib;
                
                // Convert.ToInt32(resd.PackageTariff.EnglishTariff);
                numberofchar = 160;//1=160,2=146,3=153...
                numberofchar2 =146;
                numberofchar3 = 153;
            }

            //
           


            numerAllCharacter =text.Count();

            int numSMS = 1;
            if (numerAllCharacter > numberofchar && numerAllCharacter <= (numberofchar + numberofchar2)) 
                numSMS = 2;
            else if (numerAllCharacter > (numberofchar + numberofchar2) && numerAllCharacter <= (numberofchar + numberofchar2 + numberofchar3)) 
                numSMS = 3;
            else numSMS = (numerAllCharacter / 67 + 1);//>201 
            
            
            double pri = numSMS * tt;


            return new List<double> { numSMS, pri };

        }

        public List<double> CalculatenumberSmSandPriceomomi(long idkhatersal, string text, long userid)
        {

            var khototUSer = _context.PublicKhotots.Include(h => h.SarKhat).Where(i => i.LineNumber == idkhatersal).FirstOrDefault();
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
            if (numerAllCharacter > numberofchar && numerAllCharacter <= (numberofchar + numberofchar2))
                numSMS = 2;
            else if (numerAllCharacter > (numberofchar + numberofchar2) && numerAllCharacter <= (numberofchar + numberofchar2 + numberofchar3))
                numSMS = 3;
            else numSMS = (numerAllCharacter / 67 + 1);//>201 


            double pri = numSMS * tt;


            return new List<double> { numSMS, pri };

        }

        //NEW 14010504
        public long PostUserSMS(RequestSendSMS request)
        {
            var user = _context.Users.Include(r => r.USerType).Where(u => u.IdUser == request.IdUser).FirstOrDefault();

            double PriceFinal = 0;
            int LenghSMS = 1;
            var khototUSer = _context.KhototUsers.Include(h => h.SarKhat).Where(i => i.KhatNumber == request.KhatSend).FirstOrDefault();
            if (khototUSer != null)
            {
                double pricwithoutOperator = 0;
                //if (request.CountSms == null || request.Price == null)
                //{
                List<double> c = CalculatenumberSmSandPricekhososi(request.KhatSend, request.Body);
                LenghSMS = (int)c[0];
                //request.CountSms = LenghSMS;
                pricwithoutOperator = c[1];
                //request.Price = pricwithoutOperator;
                //} 
                // pricwithoutOperator = request.Price;  

                //محاسبه هزینه ارسال کل پیام ها به گیرنده های مختلف مبتی بر اپراتورهای مختلف
               
                foreach (var to in request.Resiver)
                {

                    int idoper = CalcuateOperator(to);
                    if (idoper == 1)//hamrahaval
                        pricwithoutOperator *= khototUSer.SarKhat.HamrahAvalZarib;
                    else if (idoper == 2)//irancel
                        pricwithoutOperator *= khototUSer.SarKhat.IranselZarib;
                    else //if(idoper==3) Raytel
                        pricwithoutOperator *= khototUSer.SarKhat.RaytelZarib;
                    PriceFinal = +pricwithoutOperator;
                }
            }
            else
            {
                var khototUSer2 = _context.PublicKhotots.Include(h => h.SarKhat).Where(i => i.LineNumber == request.KhatSend).FirstOrDefault();

              //  var user = _context.Users.Include(r => r.USerType).Where(u => u.Id == request.IdUser).FirstOrDefault();
                double pricwithoutOperator = 0;
                //if (request.CountSms == null || request.Price == null)
                //{
                List<double> c = CalculatenumberSmSandPriceomomi(request.KhatSend, request.Body, request.IdUser);

                 LenghSMS = (int)c[0];
                //request.CountSms = LenghSMS;
                pricwithoutOperator = c[1];
                //request.Price = pricwithoutOperator;
                //} 
                // pricwithoutOperator = request.Price;  

                //محاسبه هزینه ارسال کل پیام ها به گیرنده های مختلف مبتی بر اپراتورهای مختلف

                foreach (var to in request.Resiver)
                {

                    int idoper = CalcuateOperator(to);
                    if (idoper == 1)//hamrahaval
                        pricwithoutOperator *= khototUSer2.SarKhat.HamrahAvalZarib;
                    else if (idoper == 2)//irancel
                        pricwithoutOperator *= khototUSer2.SarKhat.IranselZarib;
                    else //if(idoper==3) Raytel
                        pricwithoutOperator *= khototUSer2.SarKhat.RaytelZarib;
                    PriceFinal = +pricwithoutOperator;
                }
            }

            var ressuulltt=  _context.SMessageS.Add(
                new Domain.Entities.WriteModels.SMS.SMS.SMessageS 
                { 
                    IdUser=request.IdUser,
                    Price= PriceFinal,
                    CountSms= LenghSMS,
                    KhatSend= request.KhatSend,
                    DateofLimitet= request.DateofLimitet,
                    DateOfsend=request.DateOfsend,
                    IdTypeSMS= request.IdTypeSMS,
                    PeriodSendly= request.PeriodSendly,
                    TimeOfsend= request.TimeOfsend,
                    Txt=request.Body
                    
                });
           // _context.SaveChangesAsync();
            _context.SaveChanges();
           
            //_context.SaveChangesAsync();
            //14040420 - and 14010610 . 
            foreach (var resiver in request.Resiver)
            {

                _context.SMS_Resivers.Add(
                    new Domain.Entities.WriteModels.SMS.SMS.SMS_Resivers
                    {
                    //IdSMS = _context.SMSUsers.Last().Id,
                    IdSMS = ressuulltt.Entity.Id,
                    DateSended = request.DateSended, 
                    DateDelivered = request.DateDelivered,
                    Deliverd=request.Deliverd,
                    Resiver = resiver,
                   // Resiver = request.Resiver,
                    SendStatus = request.SendStatus, 
                    TypeofResiver=user.USerType.Id
                    
                    }
                );
               // _context.SaveChangesAsync();
                _context.SaveChanges();
               // _context.SaveChangesAsync();
            }
            //
            // 

            return ressuulltt.Entity.Id;
        }

        //in other Service= PostQSErvice
        //public long PostUserSMSinQu(RequestQeueSMSUser request)
        //{
        //    foreach (var resiver in request.Resiver)
        //    {
        //        QeueofSMS user = new QeueofSMS()
        //        {
        //            IdKhatSend=request.IdSMS

        //        };


        //        var res1 = _context.QeueofSMs.Add(user);
        //        _context.SaveChanges(); 
        //    }

        //    // var res = _context.QSMSUsers.AsQueryable().ToList();


        //    //var usseerrss = from us in res
        //    //                select new ResultGetQeueUserSMS()
        //    //                {
        //    //                    Body = us.Body,
        //    //                    DateSendStart = us.DateSendStart,
        //    //                    Periority = us.Periority,
        //    //                    Type = us.Type,
        //    //                    Id = us.Id,
        //    //                    IdUser = us.IdUser,
        //    //                    Resiver = us.Resiver,
        //    //                };
        //    ////== Mapper.ReferenceEquals(response, r);



        //    //var result = new List<ResultGetQeueUserSMS>();
        //    //result.AddRange(usseerrss.ToArray());
        //    //return result;
        //    return 1;
        //}



    }
}
