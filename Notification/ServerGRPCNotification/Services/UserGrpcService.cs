using AutoMapper;
using Google.Protobuf.Collections;
using Grpc.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Delete;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.AddDoc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.DeleteDoc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.AddKhat;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.DeleteKhat;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Transaction.AddTrans;
using Notification.Application.ApplicationbyMediator.UserApplication.Queries.GetById;
using Notification.Domain.Entities.ReadModels;

namespace ServerGRPCNotification.Services
{
    //[Authorize]
    public class UserGrpcService : UserGrpc.UserGrpcBase
    {
        private readonly IMediator _mediator;

        public UserGrpcService(IMediator mediator)
        {
            _mediator = mediator;
        }

        /////////////////////// USER
        public override Task<IdObject> Enroll(UserEnrollRequest request, ServerCallContext context)
        {
            //1 Aoutomaper
            var confid = new MapperConfiguration(cfg => { cfg.CreateMap<EnrollUserRequest, UserEnrollRequest>().ReverseMap(); });
            var mapperr = confid.CreateMapper();
            EnrollUserRequest req = mapperr.Map<UserEnrollRequest, EnrollUserRequest>(request);

            //2 Manual
            //var t = _mediator.Send(new EnrollUserRequest { CreditFinance = request.CreditFinance, CridetMeaasage = request.CridetMeaasage, IdRole = request.IdRole, IdUser = request.IdUser,IdUsertype=request.IdUsertype,Phone=request.Phone }); ;

            var resp = _mediator.Send(req).Result;

            return Task.FromResult(new IdObject { Id = resp.Id });
            // return base.Enroll(request, context);

        }

        [HttpGet]
        public override async Task<GetUserByIdResponce> GetUserById(IdObject request, ServerCallContext context)
        {
            var query = await _mediator.Send(new GetUserByIdRequest { IdUser = request.Id });
            if (query != null)
            {
                ////1 Aoutomaper
                //var confid = new MapperConfiguration(cfg => { cfg.CreateMap<GetUserByIdResponce, SMSUser>().ReverseMap(); });
                //var mapperr = confid.CreateMapper();
                //GetUserByIdResponce responce = mapperr.Map<SMSUser, GetUserByIdResponce>(query);

                // return responce; 
                var d = new List<Docclasgrpc>();
                var k = new List<KhototUSergrpc>();
                if (query.DocUser != null)
                    foreach (var us in query.DocUser)
                    {
                        var grpcitem = new Docclasgrpc
                        {
                            Id = us.id,
                            PathofSave = us.PathofSave,
                            TypeofDoc = us.TypeofDoc,
                            Confirmcheck = us.Confirmcheck
                        };
                        d.Add(grpcitem);
                    }

                if (query.KhototUser != null)
                    foreach (var us in query.KhototUser)
                    {
                        var k0 = new Sarkhatgrpc
                        {
                            BasePrice = us.SarKhat.BasePrice,
                            EnglishZarib = us.SarKhat.EnglishZarib,
                            HamrahAvalZarib = us.SarKhat.HamrahAvalZarib,
                            IranselZarib = us.SarKhat.IranselZarib,
                            PersianZarib = us.SarKhat.PersianZarib,
                            RaytelZarib = us.SarKhat.RaytelZarib,
                            SarKhatNumber = us.SarKhat.SarKhatNumber,
                            Spacial = us.SarKhat.Spacial,
                            TejasriLinkZarib = us.SarKhat.TejasriLinkZarib
                        };
                        var grpcitem = new KhototUSergrpc
                        {
                            Id = us.id,
                            DedlineKhat = us.DedlineKhat.ToString(),
                            KhatNumber = us.KhatNumber,
                            Statuse = us.Statuse,
                            Type = us.Type,
                        };
                        grpcitem.SarKhat.Add(k0);

                        k.Add(grpcitem);
                    }

                var responce = new GetUserByIdResponce
                {
                    Id = query.Id,
                    CreditFinance = query.CreditFinance,
                    IdUser = query.IdUser,
                    CridetMeaasage = query.CridetMeaasage,
                    // DocUser = d,
                    //KhototUser = new KhototUSergrpc { Sarkhatgrpc },// query.KhototUser,
                    Phone = query.Phone,
                    Role = query.Role,
                    TitlePackage = query.TitlePackage,
                    TitleUsertype = query.TitleUsertype,
                    ZaribTakhfif = query.ZaribTakhfif
                };
                responce.DocUser.AddRange(d);
                responce.KhototUser.AddRange(k);

                return responce;
            }
            return new GetUserByIdResponce { Id="کاربری با این خصوصیت وجود ندارد "};
        }

        [HttpDelete]
        public override async Task<IdObject> DeleteUSer(IdObject request, ServerCallContext context)
        {
            var iduser= await _mediator.Send(new DeleteUserRequest { IdUser = request.Id });
            return new IdObject { Id=iduser.Id};
        }
        ////////////////////////////////////
        ///
        //USER: Documents
        [HttpPost]
        public override Task<IdObject> AddDoc(AddDocGrpcRequest request, ServerCallContext context)
        {

            var confid = new MapperConfiguration(cfg => { cfg.CreateMap<AddDocRequest, AddDocGrpcRequest>().ReverseMap(); });
            var mapperr = confid.CreateMapper();
            AddDocRequest req = mapperr.Map<AddDocGrpcRequest, AddDocRequest>(request);

            var resp = _mediator.Send(req).Result;
            return Task.FromResult(new IdObject { Id = resp.Iddoc });

        }
        [HttpPost]
        public override async Task<IdObject> AddTransaction(AddTransactionGRPCRequest request, ServerCallContext context)
        {

            var confid = new MapperConfiguration(cfg => { cfg.CreateMap<AddTransactionRequest, AddTransactionGRPCRequest>().ReverseMap(); });
            var mapperr = confid.CreateMapper();
            AddTransactionRequest req = mapperr.Map<AddTransactionGRPCRequest, AddTransactionRequest>(request);

            var re = await _mediator.Send(req);
            return new IdObject { Id = re.IdTrans };
        }
        [HttpDelete]
        public override async Task<IdObject> DeleteDoc(DeleteDocGrpcRequest request, ServerCallContext context)
        {
            var iddoc = await _mediator.Send(new DeleteDocRequest { idUser = request.IdUser,idDoc=request.IdDoc });
            return new IdObject { Id = iddoc.idDoc }; 
        }

        ////////////////////////////////SMS
        [HttpPost]
        public override async Task<AddSMSinQGRPCResponse> SendSMS(AddSMSinQGRPCRequest request, ServerCallContext context)
        {
            List<string> Resiver = new List<string>();
            foreach(var r in request.Message.To)Resiver.Add(r);

            var re = await _mediator.Send(new AddSMSinQRequest
            {
                message = new Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS.Message { IdTypeSMS = request.Message.IdTypeSMS, KhatSend = request.Message.KhatSend, to = Resiver, txt = request.Message.Txt, TypeofResiver = request.Message.TypeofResiver },
                schaduleSendSMS = new Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS.SchaduleSendSMS { dateofLimitet =Convert.ToDateTime( request.SchaduleSendSMS.DateofLimitet),dateOfsend=request.SchaduleSendSMS.DateOfsend,periodSendly=request.SchaduleSendSMS.PeriodSendly,periority=request.SchaduleSendSMS.Periority,timeOfsend=request.SchaduleSendSMS.TimeOfsend },
                userOfSMS = new Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS.UserOfSMS {Iduser= request.UserOfSMS.Iduser,PhoneUser=request.UserOfSMS.PhoneUser }
            });
            var result = new AddSMSinQGRPCResponse();
            result.IdqeueSMS.AddRange(re.idqeueSMS);
            return result;
        }

        ////////////////////////////////Khat
        [HttpPost]
        public override async Task<IdObject> AddKhat(AddKhatGRPCRequest request, ServerCallContext context)
        {
            var confid = new MapperConfiguration(cfg => { cfg.CreateMap<AddKhatGRPCRequest, AddKhatRequest>().ReverseMap(); });
            var mapperr = confid.CreateMapper();
            AddKhatRequest req = mapperr.Map<AddKhatGRPCRequest, AddKhatRequest>(request);

            var re = await _mediator.Send(req);
            return new IdObject { Id = re.Idkhat };
        }
        [HttpDelete]
        public override async Task<IdObject> Deletekhat(DeletKhatGRPCRequest request, ServerCallContext context)
        {
            var iddoc = await _mediator.Send(new DeletKhatRequest {idUser = request.IdUser,idkhat= request.Idkhat });
            return new IdObject { Id = iddoc.idkhat };
        }
    }
}
