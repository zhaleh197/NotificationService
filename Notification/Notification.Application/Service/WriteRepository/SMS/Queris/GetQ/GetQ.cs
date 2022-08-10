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
            var res = _context.QeueofSMs.ToList().Select
               (us => new ResponceGetQeueSMSmodel
               {
                   dateOfsend=Convert.ToDateTime( us.dateOfsend),
                   dateofLimitet= Convert.ToDateTime(us.dateofLimitet),
                   to=us.to,
                   IdUser=us.IdUser,
                   periodSendly=us.periodSendly,
                   periority=us.periority,
                   //timeOfsend=TimeSpan.Parse(us.timeOfsend),
                   timeOfsend = DateTime.Parse(us.timeOfsend),
                   Id =us.Id,
                   txt=us.txt,
                   TypeofResiver=us.TypeofResiver,
                   
               }).ToList(); 

            return res;
        }

        public ResponceGetQeueSMSmodel GetsSMSinQbyId(long Id )
        {

            var res = _context.QeueofSMs.Where(q => q.Id == Id).FirstOrDefault();
            return new ResponceGetQeueSMSmodel { 
                Id= res.Id,
            dateofLimitet=Convert.ToDateTime( res.dateofLimitet),
                //dateOfsend=DateOnly.FromDateTime( res.dateOfsend),
            dateOfsend = Convert.ToDateTime(res.dateOfsend),
             
            IdUser =res.IdUser,
            periodSendly=res.periodSendly,
            periority=res.periority,
            //timeOfsend=TimeOnly.FromTimeSpan( res.timeOfsend),
            timeOfsend = DateTime.Parse(res.timeOfsend),
            to =res.to,
            txt=res.txt,
            TypeofResiver=res.TypeofResiver};
        }
        public ResponceGetQeueSMSmodel UpdateSMSinQbyIdF(long Id, DateOnly dateESeralJadid, TimeSpan timeESeralJadid)
        {
            var res = _context.QeueofSMs.SingleOrDefault(b => b.Id == Id);
            if (res != null)
            {
                res.dateOfsend = dateESeralJadid. ToString();
                res.timeOfsend = timeESeralJadid.ToString() ;
                _context.SaveChanges();
            }
            return new ResponceGetQeueSMSmodel
            {
                Id = res.Id,
                dateofLimitet =Convert.ToDateTime( res.dateofLimitet),
                dateOfsend = Convert.ToDateTime( res.dateOfsend).Date,
                IdUser = res.IdUser,
                periodSendly = res.periodSendly,
                periority = res.periority,
                //timeOfsend = TimeSpan.Parse(res.timeOfsend),
                timeOfsend = DateTime.Parse(res.timeOfsend),
                to = res.to,
                txt = res.txt,
                TypeofResiver = res.TypeofResiver
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
