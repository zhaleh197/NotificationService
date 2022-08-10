using AutoMapper;
using Notification.Application.Interface.Context;
using Notification.Domain.Entities.Email;
using Notification.Domain.Entities.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.Notification.Queris.Get
{
    public class GetNotification : IGetNotification
    {
        private readonly IDatabaseContext _context;
        public GetNotification(IDatabaseContext context)
        {
            _context = context;
        }
        public List<ResultGetClientNotification> GetClientNotification()
        {
            var res=_context.NotificationClients.AsQueryable().ToList();

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<List<NotificationClient>, List<ResultGetClientNotification>>()
            );
            var mapper = new Mapper(config);

            var result = mapper.Map<List<ResultGetClientNotification>>(res);
            //AutoMapper();
            return result;
        }
        public List<ResultGetUserNotification> GetUserNotification()
        {
            var res = _context.NotificationUsers.AsQueryable().ToList();

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<List<NotificationUser>, List<ResultGetUserNotification>>()
            );
            var mapper = new Mapper(config);

            var result = mapper.Map<List<ResultGetUserNotification>>(res);
            //AutoMapper();
            return result;
        }

    }
}
