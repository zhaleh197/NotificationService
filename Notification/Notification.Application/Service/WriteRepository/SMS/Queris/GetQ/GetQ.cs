using Notification.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.SMS.Queris.GetQ
{
    public class GetQ : IGetQ
    {
        private readonly IDatabaseContext _context;
        public GetQ(IDatabaseContext context)
        {
            _context = context;
        }
        public long DeleteSMSinQbyId(long Id)
        {
            var res = _context.QeueofSMs.SingleOrDefault(b => b.Id == Id);
            if (res != null)
            {
                _context.QeueofSMs.Remove(res);
                _context.SaveChanges();
                return res.Id;
            }
            return 0;
        }
        public List<ResponceGetQeueSMSmodel> GetQeueUserSMS()
        {
            var res = _context.QeueofSMs.AsQueryable();
            if (res != null)
            {
                res.Select
                 (us => new ResponceGetQeueSMSmodel
                 {
                     DateOfsend = Convert.ToDateTime(us.DateOfsend).ToString(),
                     DateofLimitet = Convert.ToDateTime(us.DateofLimitet).ToString(),
                     to = us.to,
                     IdUser = us.IdUser,
                     PeriodSendly = us.PeriodSendly,
                     //timeOfsend=TimeSpan.Parse(us.timeOfsend),
                     TimeOfsend = DateTime.Parse(us.TimeOfsend).ToString(),
                     Id = us.Id,
                     txt = us.txt,
                     TypeofResier = us.TypeofResiver,
                     CountSms = us.CountSms,
                     KhatSend = us.KhatSend,
                     // IdKhatSend = us.IdKhatSend,
                     IdTypeSMS = us.IdTypeSMS,
                     Price = us.Price

                 }).ToList();
            }
            return null;
        }

     

        public ResponceGetQeueSMSmodel GetsSMSinQbyId(long Id)
        {

            var us = _context.QeueofSMs.Where(q => q.Id == Id).FirstOrDefault();

            if (us == null) return null;
            return new ResponceGetQeueSMSmodel
            {
                DateOfsend = Convert.ToDateTime(us.DateOfsend).ToString(),
                DateofLimitet = Convert.ToDateTime(us.DateofLimitet).ToString(),
                to = us.to,
                IdUser = us.IdUser,
                PeriodSendly = us.PeriodSendly,
                //timeOfsend=TimeSpan.Parse(us.timeOfsend),
                TimeOfsend = DateTime.Parse(us.TimeOfsend).ToString(),
                Id = us.Id,
                txt = us.txt,
                TypeofResier = us.TypeofResiver,
                CountSms = us.CountSms,
                KhatSend = us.KhatSend,
               // IdKhatSend = us.IdKhatSend,
                IdTypeSMS = us.IdTypeSMS,
                Price = us.Price

            };

        }
        public ResponceGetQeueSMSmodel UpdateSMSinQbyIdF(long Id, DateOnly dateESeralJadid, string timeESeralJadid)
        {
            var us = _context.QeueofSMs.SingleOrDefault(b => b.Id == Id);
            if (us == null) return null;

            us.DateOfsend = dateESeralJadid.ToString();
            us.TimeOfsend = timeESeralJadid.ToString();
            _context.SaveChanges();

            return new ResponceGetQeueSMSmodel
            {
                DateOfsend = Convert.ToDateTime(us.DateOfsend).ToString(),
                DateofLimitet = Convert.ToDateTime(us.DateofLimitet).ToString(),
                to = us.to,
                IdUser = us.IdUser,
                PeriodSendly = us.PeriodSendly,
                //timeOfsend=TimeSpan.Parse(us.timeOfsend),
                TimeOfsend = DateTime.Parse(us.TimeOfsend).ToString(),
                Id = us.Id,
                txt = us.txt,
                TypeofResier = us.TypeofResiver,
                CountSms = us.CountSms,
                KhatSend = us.KhatSend,
                //IdKhatSend = us.IdKhatSend,
                IdTypeSMS = us.IdTypeSMS,
                Price = us.Price

            };
        }

        //    public ResponceGetQeueSMSmodel UpdateSMSinQbyId(long Id, DateOnly dateESeralJadid,TimeOnly timeESeralJadid)
        //    {
        //        var res = _context.QeueofSMs.SingleOrDefault(b => b.Id == Id); 
        //        if (res != null)
        //        {
        //            res.dateOfsend = dateESeralJadid.ToDateTime(timeESeralJadid);
        //            res.timeOfsend = timeESeralJadid.ToTimeSpan();

        //            _context.SaveChanges();
        //        }
        //        return new ResponceGetQeueSMSmodel
        //        {
        //            Id = res.Id,
        //            dateofLimitet = res.dateofLimitet,
        //            dateOfsend = DateOnly.FromDateTime(res.dateOfsend),
        //            IdUser = res.IdUser,
        //            periodSendly = res.periodSendly,
        //            periority = res.periority,
        //            timeOfsend = TimeOnly.FromTimeSpan(res.timeOfsend),
        //            to = res.to,
        //            txt = res.txt,
        //            TypeofResiver = res.TypeofResiver
        //        };
        //    }
    }

}
