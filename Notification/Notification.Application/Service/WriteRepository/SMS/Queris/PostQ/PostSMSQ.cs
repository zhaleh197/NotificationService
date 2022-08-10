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
        public List<long> PostUserSMSinQ(RequestQeueSMSmodel request)
        {
            List<long> re = new List<long>();
            foreach (var ito in request.to)
            {
                QeueofSMS smsq = new QeueofSMS()
                {
                    dateofLimitet = request.dateofLimitet.ToString(),
                    dateOfsend = request.dateOfsend.Date.ToString(),
                    IdUser = request.IdUser,
                    periodSendly = request.periodSendly,
                    periority = request.periority,
                    timeOfsend = request.timeOfsend.TimeOfDay.ToString(),
                    txt = request.txt,
                    TypeofResiver = request.TypeofResiver,
                    to = ito,
                    InsertTime = DateTime.Now,
                    IsRemoved = false,
                    RemoveTime = null,
                    UpdateTime = null

                };
               var t= _context.QeueofSMs.Add(smsq);
                _context.SaveChanges();
                re.Add(t.Entity.Id);
            } 

            return re;
        }
    }
}
