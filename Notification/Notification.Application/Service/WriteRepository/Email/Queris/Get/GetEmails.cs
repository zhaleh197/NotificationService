using AutoMapper;
using Notification.Application.Interface.Context;
using Notification.Domain.Entities.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.Email.Queris.Get
{
    public class GetEmails : IGetEmails
    {
        private readonly IDatabaseContext _context;
        public GetEmails(IDatabaseContext context)
        {
            _context = context;
        }
        public List<ResultGetClientEmails> GetClientEmail()
        {
            var res=_context.EmailClients.AsQueryable().ToList();

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<List<EmailClient>, List<ResultGetClientEmails>>()
            );
            var mapper = new Mapper(config);

            var result = mapper.Map<List<ResultGetClientEmails>>(res);
            //AutoMapper();
            return result;
        }
        public List<ResultGetUserEmails> GetUserEmail()
        {
            var res = _context.EmailUsers.AsQueryable().ToList();

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<List<EmailUser>, List<ResultGetUserEmails>>()
            );
            var mapper = new Mapper(config);

            var result = mapper.Map<List<ResultGetUserEmails>>(res);
            //AutoMapper();
            return result;
        }

    }
}
