 
using AutoMapper;
using Grpc.Core;
using MediatR;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add;

namespace GrpcNotification.Services
{
    public class UserGrpcService : UserGrpc.UserGrpcBase
    {
        //private readonly IMediator _mediator;

        //public UserGrpcService(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}
        //public override Task<UserEnrollresponse> Enroll(UserEnrollRequest request, ServerCallContext context)
        //{
        //    var confid = new MapperConfiguration(cfg=> { cfg.CreateMap<UserEnrollRequest, UserEnrollRequest>().ReverseMap(); });
        //    var mapperr = confid.CreateMapper();
        //    UserEnrollRequest req = mapperr.Map<UserEnrollRequest, UserEnrollRequest>(request);
        //   var t= _mediator.Send(req);

        //      //Task.FromResult(new UserEnrollresponse { Id = 1 }) ;
        //    return base.Enroll(request, context);
        //}
        public override Task<UserEnrollresponse> Enroll(UserEnrollRequest request, ServerCallContext context)
        {
            return base.Enroll(request, context);
        }

    }
}