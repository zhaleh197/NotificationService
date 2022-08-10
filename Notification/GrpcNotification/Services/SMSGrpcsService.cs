
using GrpcNotification;
using Grpc.Core;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Interface.Context;
using Notification.Application.Service.SMS.Queris.Get;
using AutoMapper;

namespace GrpcNotification.Services
{
    public class SMSGrpcsService : SMSGrpcs.SMSGrpcsBase
    { 
        private readonly ILogger<SMSGrpcsService> _logger;
        private readonly ISMSService _sMSService;
        //private readonly IGetSMS _getSMS;
    
        //public IDatabaseContext _dbContext;
        public SMSGrpcsService(ISMSService sMSService,
            ILogger<SMSGrpcsService> logger,
            //IDatabaseContext dbContext,
             IGetSMS getSMS)
        {
            _logger = logger;
            _sMSService = sMSService;
            //_dbContext = dbContext;
            //_getSMS = getSMS;
        }
        public override Task<SMSresponse> SendSMSGrpc(SMSRequest request, ServerCallContext context)
        {
            try
            {
               //var f = "";
                _sMSService.SMSF(new SMSSendRequest2 { to = request.To, txt = request.Txt });

            return  Task.FromResult(
                new SMSresponse
                {
                    Res = true
                }  );
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
        //    Mapper.ReferenceEquals(response, r);
        //    response.Items.AddRange(r.ToArray());
        //    return await Task.FromResult(response);

        //}
        //#endregion

        //#region GetUserSMS
        //public override async Task<ListResultGetUserSMS1> GetUserSMS(Empty request, ServerCallContext context)
        //{
        //    ListResultGetUserSMS1 response = new ListResultGetUserSMS1();

        //    var r = _getSMS.GetUserSMS();
        //    Mapper.ReferenceEquals(response, r);
        //    response.Items.AddRange(r.ToArray());
        //    return await Task.FromResult(response);
        //}
        //#endregion
        //#region PostInsert
        //public override Task<Product> Post(Product request, ServerCallContext context)
        //{
        //    var prdAdded = new Models.Product()
        //    {
        //        ProductId = request.ProductId,
        //        ProductName = request.ProductName,
        //        CategoryName = request.CategoryName,
        //        Manufacturer = request.Manufacturer,
        //        Price = request.Price
        //    };
        //    var res = dbContext.Products.Add(prdAdded);
        //    dbContext.SaveChanges();
        //    var response = new Product()
        //    {
        //        ProductRowId = res.Entity.ProductRowId,
        //        ProductId = res.Entity.ProductId,
        //        ProductName = res.Entity.ProductName,
        //        CategoryName = res.Entity.CategoryName,
        //        Manufacturer = res.Entity.Manufacturer,
        //        Price = res.Entity.Price
        //    };
        //    return Task.FromResult<Product>(response);
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
        //#endregion
    }

}
