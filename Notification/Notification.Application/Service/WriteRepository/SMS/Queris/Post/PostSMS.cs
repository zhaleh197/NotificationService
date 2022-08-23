using Microsoft.EntityFrameworkCore;
using Notification.Application.Interface.Context;
using Notification.Application.Service.Common;
using Notification.Domain.Entities.SMS.QeueSend;
using Notification.Domain.Entities.SMS.SMS;
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


        //NEW 14010504
        public long PostUserSMS(RequestSMSUser request)
        {
            var resd = _context.Users.Include(s => s.PackageTariff.PackageSMS).Where(q => q.IdUser == request.IdUser).FirstOrDefault();
            string text = request.Body;
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
            int tt = 0;
            int numerAllCharacter = 0;
            int numberofchar = 1;
            if (result == "Persian")
            {
                tt = Convert.ToInt32(resd.PackageTariff.FarsiTariff);
                numberofchar = 20;
            }
            else //if txt is English
            { 
                tt = Convert.ToInt32(resd.PackageTariff.EnglishTariff);
                numberofchar = 32;
            }
             numerAllCharacter = request.Body.Count();
            int pri = (numerAllCharacter / numberofchar+1) * tt;

            SMSUser user = new SMSUser()
            {
                IdUser = request.IdUser,
                Body = request.Body,
                Price = pri,
                
                //DateDelivere=request.DateDelivere,
                // DateSend=request.DateSend,


                //Resiver=request.Resiver,
                // Status=request.Status,
                InsertTime = DateTime.Now,
                IsRemoved = false,
                RemoveTime = null,
                UpdateTime = null

            };
            var ressuulltt=   _context.SMSUsers.Add(user);
            _context.SaveChanges();

            //14040420
           // foreach (var resiver in request.Resiver)
            //{
                _context.SMS_Resivers.Add(
                    new SMS_Resivers() 
                    {
                    //IdSMS = _context.SMSUsers.Last().Id,
                    IdSMS = ressuulltt.Entity.Id,
                    DateSend = request.DateSend, 
                    DateDelivere = request.DateDelivere,
                    Deliverd=request.Delivered,
                    //Resiver = resiver,
                    Resiver = request.Resiver,
                    SendStatus = request.Status, 
                    }
                );

                _context.SaveChanges();
           // }
            //
            // 

            return ressuulltt.Entity.Id;
        }

        public int PostUserSMSinQu(RequestQeueSMSUser request)
        {
            foreach (var resiver in request.Resiver)
            {
                QeueSMS user = new QeueSMS()
                {
                    //IdUser = request.IdUser,
                    //Body = request.Body, 
                    //Resiver=request.Resiver,
                    IdSMS = request.IdSMS,
                    Periority = request.Periority,
                    DateSendStart = request.DateSendStart,
                    Type = request.Type,
                    //SendStatus = request.SendStatus,
                    //DateDelivere = request.DateDelivere,
                    //DateSend = request.DateSend,
                    //Resiver = resiver,
                    
                    InsertTime = DateTime.Now,
                    IsRemoved = false,
                };


                var res1 = _context.QSMSUsers.Add(user);
                _context.SaveChanges();
            }

            // var res = _context.QSMSUsers.AsQueryable().ToList();


            //var usseerrss = from us in res
            //                select new ResultGetQeueUserSMS()
            //                {
            //                    Body = us.Body,
            //                    DateSendStart = us.DateSendStart,
            //                    Periority = us.Periority,
            //                    Type = us.Type,
            //                    Id = us.Id,
            //                    IdUser = us.IdUser,
            //                    Resiver = us.Resiver,
            //                };
            ////== Mapper.ReferenceEquals(response, r);



            //var result = new List<ResultGetQeueUserSMS>();
            //result.AddRange(usseerrss.ToArray());
            //return result;
            return 1;
        }


    }
}
