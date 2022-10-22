
using AutoMapper;
using Grpc.Core;
using Notification.Application.Interface.Context;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Get;
using ServerGRPCNotification;
//using Grpc.Core;
//using Notification.Application.Service.SMS.Commands;
//using Notification.Application.Interface.Context;
//using Notification.Application.Service.SMS.Queris.Get;
//using AutoMapper;

using Google.Protobuf.WellKnownTypes;
using Notification.Application.Service.Common;
using Notification.Application.Service.SMS.Queris.Post;
using static Notification.Application.Service.SMS.Queris.Post.RequestPostSMS;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ServerGRPCNotification.Services
{
    [Authorize]
    public class SMSGrpcsService : SMSGrpcs.SMSGrpcsBase
    {


        private readonly ILogger<SMSGrpcsService> _logger;
        private readonly ISMSService _sMSService;
        //private readonly ITaskJob<ResultGetQeueUserSMS> _taskJob;
        private readonly ITaskJobs _taskJob;
        private readonly IGetSMS _getSMS;
        private readonly IPostSMS _postSMS;



        public IDatabaseContext _dbContext;
        public SMSGrpcsService(
            ISMSService sMSService,
            ILogger<SMSGrpcsService> logger,
            IDatabaseContext dbContext,
            IGetSMS getSMS,
            IPostSMS postSMS
            //,ITaskJob<ResultGetQeueUserSMS> taskJob,
           , ITaskJobs taskJob

            )
        {
            _logger = logger;
            _sMSService = sMSService;
            _dbContext = dbContext;
            _getSMS = getSMS;
            _postSMS = postSMS;
            _taskJob = taskJob;
        }
        public override Task<SMSresponse> SendSMSGrpc(SMSRequest request, ServerCallContext context)
        {
            var userID = context.GetHttpContext().User.FindFirstValue(ClaimTypes.NameIdentifier);
            string UserId = Convert.ToString(userID);

            try
            {
                //var f = "";
                //_sMSService.SMSF(new SMSSendRequest2 { to = request.To, txt = request.Txt });

                return Task.FromResult(
                    new SMSresponse
                    {
                        Res = true
                    });
            }
            catch (RpcException e)
            {
                Console.WriteLine("Remote procedure call failed: " + e);
                throw;
            }
        }



        //#region GetQeueUserSMS
        //public override async Task<ListResultGetQeueUserSMS1> GetQeueUserSMS(Empty request, ServerCallContext context)
        //{
        //    ListResultGetQeueUserSMS1 response = new ListResultGetQeueUserSMS1();
        //    var r = _getSMS.GetQeueUserSMS();

        //    //var usseerrss = from us in r
        //    //                select new ResultGetQeueUserSMS1()
        //    //                {
        //    //                    //Resiver=us.Resiver,
        //    //                    Body = us.Body,
        //    //                    DateSendStart = Timestamp.FromDateTimeOffset(us.DateSendStart),
        //    //                    Id = us.Id,
        //    //                    IdUser = us.IdUser,
        //    //                    Periority = us.Periority,
        //    //                    Type = us.Type
        //    //                };

        //    ////== Mapper.ReferenceEquals(response, r);
        //    var usseerrss = new List<ResultGetQeueUserSMS1>();
        //    foreach (var us in r)
        //    {
        //        var grpcitem = new ResultGetQeueUserSMS1();
        //        grpcitem.Body = us.Body;
        //        grpcitem.DateSendStart = Timestamp.FromDateTimeOffset(us.DateSendStart);
        //        grpcitem.Id = us.Id;
        //        grpcitem.IdUser = us.IdUser;
        //        grpcitem.Type = us.Type;
        //        grpcitem.Periority = us.Periority; 
        //        grpcitem.Resiver.AddRange(us.Resiver);
        //        usseerrss.Add(grpcitem);
        //    }
        //    response.Items.AddRange(usseerrss.ToArray());

        //    //_taskJob.Qeuetask.Enqueue(new ResultGetQeueUserSMS
        //    //{
        //    //    Body = response.Items[0].Body,
        //    //    DateSendStart = response.Items[0].DateSendStart,
        //    //    Periority = response.Items[0].Periority,
        //    //    Resiver = response.Items[0].Resiver,
        //    //    Type = response.Items[0].Type
        //    //}
        //    //);

        //    return await Task.FromResult(response);
        //}
        //#endregion

        //#region GetUserSMS
        //public override async Task<ListResultGetUserSMS1> GetUserSMS(Empty request, ServerCallContext context)
        //{
        //    ListResultGetUserSMS1 response = new ListResultGetUserSMS1();

        //    var r = _getSMS.GetUserSMS();
        //    //var t = new ListResivers();
        //    //foreach(  var rr in r )
        //    //    t.Resiver.Add(rr.Resiver);

        //    //var usseerrssGRPC = from us in r
        //    //                select new ResultGetUserSMS1()
        //    //                {


        //    //                    Body = us.Body,
        //    //                    DateDelivere = Timestamp.FromDateTimeOffset(us.DateDelivere),
        //    //                    Id = us.Id,
        //    //                    IdUser = us.IdUser,
        //    //                    DateSend= Timestamp.FromDateTimeOffset(us.DateSend),
        //    //                    Status=us.Status,

        //    //                }.Resiver.AddRange(us.Resiver);
        //    var usseerrssGRPC = new List<ResultGetUserSMS1>();
        //    foreach (var us in r)
        //    {
        //        var grpcitem = new ResultGetUserSMS1();
        //        grpcitem.Body = us.Body;
        //        grpcitem.DateDelivere = Timestamp.FromDateTimeOffset(us.DateDelivere);
        //        grpcitem.Id = us.Id;
        //        grpcitem.IdUser = us.IdUser;
        //        grpcitem.DateSend = Timestamp.FromDateTimeOffset(us.DateSend);
        //        grpcitem.Status = us.Status;
        //        grpcitem.Resiver.AddRange(us.Resiver);
        //        usseerrssGRPC.Add(grpcitem);
        //    }
        //    //== Mapper.ReferenceEquals(response, r);

        //    response.Items.AddRange(usseerrssGRPC.ToArray());



        //    return await Task.FromResult(response);
        //}
        //#endregion



        #region PostInsert
        //public override Task<Resultpostsms> PostUserSMS(ResultGetUserSMS1 request, ServerCallContext context)
        //{ 
        //    //var res = _postSMS.PostUserSMS(new RequestSMSUser {
        //    //    Body = request.Body,
        //    //    DateDelivere = Convert.google.protobuf.Timestamp(request.DateDelivere),
        //    //    DateSend = Convert.ToDateTime(request.DateSend),
        //    //    IdUser = request.IdUser, 
        //    //    Resiver = request.Resiver, 
        //    //    Status = request.Status 
        //    //}
        //    //);
        //    //Timestamp.FromDateTime(DateTime.UtcNow);

        //    //var response = new Resultpostsms()
        //    //{
        //    //    Result = res,
        //    //};
        //    //return Task.FromResult(response);


        //    //var res = dbContext.Products.Add(prdAdded);
        //    //dbContext.SaveChanges();
        //    //var response = new Product()
        //    //{
        //    //    ProductRowId = res.Entity.ProductRowId,
        //    //    ProductId = res.Entity.ProductId,
        //    //    ProductName = res.Entity.ProductName,
        //    //    CategoryName = res.Entity.CategoryName,
        //    //    Manufacturer = res.Entity.Manufacturer,
        //    //    Price = res.Entity.Price
        //    //};
        //    //return Task.FromResult<Product>(response);
        //}
        //#endregion



        //#region PUTUPDATE
        //public override Task<Product> Put(Product request, ServerCallContext context)
        //{
        //    Models.Product prd = dbContext.Products.Find(request.ProductRowId);
        //    if (prd == null)
        //    {
        //        return Task.FromResult<Product>(null);
        //    }
        //    prd.ProductRowId = request.ProductRowId;
        //    prd.ProductId = request.ProductId;
        //    prd.ProductName = request.ProductName;
        //    prd.CategoryName = request.CategoryName;
        //    prd.Manufacturer = request.Manufacturer;
        //    prd.Price = request.Price;
        //    dbContext.Products.Update(prd);
        //    dbContext.SaveChanges();
        //    return Task.FromResult<Product>(new Product()
        //    {
        //        ProductRowId = prd.ProductRowId,
        //        ProductId = prd.ProductId,
        //        ProductName = prd.ProductName,
        //        CategoryName = prd.CategoryName,
        //        Manufacturer = prd.Manufacturer,
        //        Price = prd.Price
        //    });
        //}
        //#endregion
        //#region DELETE
        //public override Task<Empty> Delete(ProductRowIdFilter request, ServerCallContext context)
        //{
        //    Models.Product prd = dbContext.Products.Find(request.ProductRowId);
        //    if (prd == null)
        //    {
        //        return Task.FromResult<Empty>(null);
        //    }
        //    dbContext.Products.Remove(prd);
        //    dbContext.SaveChanges();
        //    return Task.FromResult<Empty>(new Empty());
        //}
        #endregion
    }

}
