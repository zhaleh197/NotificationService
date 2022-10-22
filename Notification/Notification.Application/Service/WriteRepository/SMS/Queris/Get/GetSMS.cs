using AutoMapper;
using Notification.Application.Interface.Context;
using Notification.Domain.Entities.SMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.Queris.Get
{
    public class GetSMS : IGetSMS
    {
        private readonly IDatabaseContext _context;
        public GetSMS(IDatabaseContext context)
        {
            _context = context;
        }
        //public List<ResultGetClientSMS> GetClientSMS()
        //{
        //    var res = _context.SMessageS.AsQueryable().ToList();

        //    var config = new MapperConfiguration(cfg =>
        //        cfg.CreateMap<List<SMessageS>, List<ResultGetClientSMS>>()
        //    );
        //    var mapper = new Mapper(config);

        //    var result = mapper.Map<List<ResultGetClientSMS>>(res);
        //    //AutoMapper();
        //    return result;
        //}

        //public List<ResultGetQeueClientSMS> GetQeueClientSMS()
        //{
        //    var res = _context.QSMSClient.AsQueryable().ToList();

        //    var config = new MapperConfiguration(cfg =>
        //        cfg.CreateMap<List<QeueSMSClient>, List<ResultGetQeueClientSMS>>()
        //    );
        //    var mapper = new Mapper(config);

        //    var result = mapper.Map<List<ResultGetQeueClientSMS>>(res);
        //    //AutoMapper();
        //    return result;
        //}

        //public List<ResultGetQeueUserSMS> GetQeueUserSMS()
        //{
        //    //var res = _context.QSMSUsers.AsQueryable().ToList();

        //    var res = _context.QSMSUsers.ToList().Select
        //        (us => new ResultGetQeueUserSMS
        //    {
        //        Body = us.SMSUser.Body,
        //        DateSendStart = us.DateSendStart,
        //        Periority = us.Periority,
        //        Type = us.Type,
        //        Id = us.Id,
        //        IdUser = us.SMSUser.Id,
        //        Resiver = us.SMSUser.SMS_Resivers.Where(s => s.IdSMS == us.Id).ToList().Select(s => s.Resiver).ToList(),



        //    }).ToList();
        //    //var usseerrss = from us in res
        //    //                select new ResultGetQeueUserSMS()
        //    //                {
        //    //                    Body = us.SMSUser.Body,
        //    //                    DateSendStart = us.DateSendStart,
        //    //                    Periority = us.Periority,
        //    //                    Type = us.Type,
        //    //                    Id = us.Id,
        //    //                    IdUser = us.SMSUser.Id,
        //    //                    Resiver=us.SMS_Resivers.Where(s => s.IdSMS == us.Id).ToList().Select(s => s.Resiver).ToList(),//14010413 // get all resiver from table SMS_Resivers

        //    //                };
        //    //== Mapper.ReferenceEquals(response, r);



        //   // var result = new List<ResultGetQeueUserSMS>();
        //    //result.AddRange(usseerrss.ToArray());



        //    //var config = new MapperConfiguration(cfg =>
        //    //    cfg.CreateMap<List<QeueSMSUser>, List<ResultGetQeueUserSMS>>()
        //    //);
        //    //var mapper = new Mapper(config);

        //    //var result = mapper.Map<List<ResultGetQeueUserSMS>>(res);
        //    ////AutoMapper();


        //    return res;
        //}

        public List<ResultGetUserSMS> GetUserSMS()
        {

            var res = _context.SMessageS.ToList().Select(us => new ResultGetUserSMS
            {
                Body = us.Txt,
                Status = us.SMS_Resivers.Where(s => s.IdSMS == us.Id).FirstOrDefault().SendStatus,
                DateOfsend = us.DateOfsend,
                CountSms = us.CountSms,
                DateofLimitet = us.DateofLimitet,
                KhatSend = us.KhatSend,
                IdTypeSMS = us.IdTypeSMS,
                PeriodSendly = us.PeriodSendly,
                Price = us.Price,
                TimeOfsend = us.TimeOfsend,
                Id = us.Id,
                IdUser = us.IdUser,
                // Resiver = us.SMS_Resivers.Where(s=>s.IdSMS==us.Id).ToList().Select(s=>s.Resiver).ToList(),//14010413 // get all resiver from table SMS_Resivers
                Resivers = us.SMS_Resivers.Where(s => s.IdSMS == us.Id).ToList().Select(
                    s => new ResiverClas
                    {
                        DateDelivered = s.DateDelivered,
                        DateSended = s.DateSended,
                        Deliverd = s.Deliverd,
                        Resiver = s.Resiver,
                        SendStatus = s.SendStatus,
                        TypeofResiver = s.TypeofResiver
                    }).ToList()

            }
            ).ToList();

            ////var config = new MapperConfiguration(cfg =>
            ////    cfg.CreateMap<List<SMSUser>, List<ResultGetUserSMS>>()
            ////);
            ////var mapper = new Mapper(config);

            ////var result = mapper.Map<List<ResultGetUserSMS>>(res);


            //AutoMapper();
            return res;
        }
        public ResultGetUserSMS GetUserSMSbyId(long id)
        {

            var us = _context.SMessageS.Where(g => g.Id == id).FirstOrDefault();
            var usersms = new ResultGetUserSMS
            {
                Body = us.Txt,
                Status = us.SMS_Resivers.Where(s => s.IdSMS == us.Id).FirstOrDefault().SendStatus,
                DateOfsend = us.DateOfsend,
                CountSms = us.CountSms,
                DateofLimitet = us.DateofLimitet,
                KhatSend = us.KhatSend,
                IdTypeSMS = us.IdTypeSMS,
                PeriodSendly = us.PeriodSendly,
                Price = us.Price,
                TimeOfsend = us.TimeOfsend,
                Id = us.Id,
                IdUser = us.IdUser,
                // Resiver = us.SMS_Resivers.Where(s=>s.IdSMS==us.Id).ToList().Select(s=>s.Resiver).ToList(),//14010413 // get all resiver from table SMS_Resivers
                Resivers = us.SMS_Resivers.Where(s => s.IdSMS == us.Id).ToList().Select(
                    s => new ResiverClas
                    {
                        DateDelivered = s.DateDelivered,
                        DateSended = s.DateSended,
                        Deliverd = s.Deliverd,
                        Resiver = s.Resiver,
                        SendStatus = s.SendStatus,
                        TypeofResiver = s.TypeofResiver
                    }).ToList()

            }; 
            return usersms;
        }
    }
}
