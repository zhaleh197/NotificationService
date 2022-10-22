using GrpcNotification.Services;
//using MailKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.Common.Behaviors;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.GetQSMS;
using Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.AddReadUser;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.DocReadUser;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.KhatReadUser;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.TransactionReadUser;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Delete;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.AddDoc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.DeleteDoc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.AddKhat;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.DeleteKhat;
using Notification.Application.ApplicationbyMediator.UserApplication.Queries.GetById;
using Notification.Application.Interface.Context;
using Notification.Application.Service.Email.Queris.Get;
using Notification.Application.Service.Notification.Commands;
using Notification.Application.Service.Notification.Queris.Get;
using Notification.Application.Service.ReadRepository.User;
//using Notification.Application.Interface.Context;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Get;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Application.Service.User.Doc;
using Notification.Application.Service.User.Enroll;
using Notification.Application.Service.User.Proj;
using Notification.Application.Service.WriteRepository.Email.Commands;
using Notification.Application.Service.WriteRepository.SMS.Queris.GetQ;
using Notification.Application.Service.WriteRepository.SMS.Queris.PostQ;
using Notification.Application.Service.WriteRepository.User.Kat;
using Notification.Application.Service.WriteRepository.User.Kat.SarKhat;
using Notification.Application.Service.WriteRepository.User.Transaction;
using Notification.Persistance.Context;
//using Notification.Application.Service.SMS.Queris.Get;
//using Notification.Persistance.Context;
//using Notification.Application.Service.SMS.Commands;
//using SMSService = Notification.Application.Service.SMS.Commands.SMSService;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682



//builder.Services.AddScoped<ISMSService, SMSService>();
//builder.Services.AddScoped<IGetSMS, GetSMS>();
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();



////For dbcontext14010218
builder.Services.AddDbContext<DatabaseContext>(item => 
item.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
    });
});
////




builder.Services.AddAuthentication("Bearer").
    AddJwtBearer("Bearer", options =>
       {
           options.Authority = "https://localhost:7254";
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateAudience = false
           };
       });




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Test Behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


//بالا اد کردم باید بینم چیست بعد این را بگذارم یا بردارم
//var conectionString = "Data Source=.;Initial Catalog=SMSServiceDB;Integrated Security=true;MultipleActiveResultSets=true";
//builder.Services.AddDbContext<DatabaseContext>(options =>
//{
//    options.UseSqlServer(conectionString,
//    b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName));
//});


#region IOC

//builder.Services.AddScoped<IDatabaseContext>(provider => provider.GetService<DatabaseContext>());
#endregion

#region Mongo Singleton Injectio
var mongoClient = new MongoClient("mongodb://localhost:27017");
var mongoDatabase = mongoClient.GetDatabase("NotificationCQRS");
builder.Services.AddSingleton(mongoDatabase);

//// Add INJECT Channel
builder.Services.AddSingleton(typeof(ChannelQueue<>));
///////

#endregion
/// 
//// Add INJECT Write repository
/// //sms
 //builder.Services.AddScoped<ITaskJob<T>, TaskJob<T>>(); 

builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IGetEmails, GetEmails>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IGetNotification, GetNotification>();

builder.Services.AddScoped<IGetSMS, GetSMS>();
builder.Services.AddScoped<ISMSService, SMSService>();//send sms
builder.Services.AddScoped<IPostSMS, PostSMS>();
builder.Services.AddScoped<IPostSMSQ, PostSMSQ>();
builder.Services.AddScoped<IGetQ, GetQ>();
builder.Services.AddScoped<IGetSMS, GetSMS>();

builder.Services.AddScoped<ILocalUser, LocalUser>();
builder.Services.AddScoped<IUserDoc, UserDoc>();
builder.Services.AddScoped<IUserProjects, UserProjects>();


builder.Services.AddScoped<ISarKhat, SarKhat>();
builder.Services.AddScoped<IKhat, Khat>();
builder.Services.AddScoped<ITransactionss, Transactionss>();




//builder.Services.AddScoped<IMailService, MailService>();




//user
builder.Services.AddMediatR(typeof(EnrollUserRequest).Assembly);
builder.Services.AddMediatR(typeof(GetUserByIdRequest).Assembly);
builder.Services.AddMediatR(typeof(DeleteUserRequest).Assembly);
//doc
builder.Services.AddMediatR(typeof(DeleteDocRequest).Assembly);
builder.Services.AddMediatR(typeof(AddDocRequest).Assembly);
//khat
builder.Services.AddMediatR(typeof(AddKhatRequest).Assembly);
builder.Services.AddMediatR(typeof(DeletKhatRequest).Assembly);
//sms
builder.Services.AddMediatR(typeof(AddSMSinQRequest).Assembly);

/// //////////////////////////////////////

//// Add INJECT Read repository
///
builder.Services.AddScoped<ReadSMSUser>();
builder.Services.AddScoped<ReadUserDoc>();
builder.Services.AddScoped<ReadUserKhat>();



//// Add INJECT SErvices for API Usual... later i must to changhed this to mediatorR
builder.Services.AddScoped<IUserProjects, UserProjects>();
builder.Services.AddScoped<IKhat, Khat>();
builder.Services.AddScoped<ISarKhat, SarKhat>();


//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//builder.Services.AddMediatR(typeof(NotificationAPICQRSEntrypoint).Assembly);
//builder.Services.AddMediatR(typeof(StartUp).GetTypeInfo().Assembly);
/// /////////////////////
/// 


//// Add INJECT BackgroundService 
builder.Services.AddHostedService<AddReadModelWorker>();
builder.Services.AddHostedService<DeleteReadModleWorker>();
builder.Services.AddHostedService<EditReadModeWorker>();

builder.Services.AddHostedService<AddDocWorker>();
builder.Services.AddHostedService<DeleteDocWorker>();

builder.Services.AddHostedService<AddKhatWorker>();
builder.Services.AddHostedService<DeleteKhatWorker>();

builder.Services.AddHostedService<AddTransactionWorker>();
//



builder.Services.AddHostedService<CheckQueueSMSWorker>();
builder.Services.AddHostedService<SendAnnualSMSWorker>();
builder.Services.AddHostedService<SendHourlySMSWorker>();
builder.Services.AddHostedService<SendDailySMSWorker>();
builder.Services.AddHostedService<SendMounthlySMSWorker>();
builder.Services.AddHostedService<SendWeeklySMSWorker>();
builder.Services.AddHostedService<SendOnceSMSWorker>();
builder.Services.AddHostedService<SendOnceSMSWorker2>();
/////////

#region Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SMS CQRS With MediatR.WebApi",
    });
});





#endregion


// Add services to the container.
//builder.Services.AddGrpc();
builder.Services.AddGrpc(opt =>
{
    opt.EnableDetailedErrors = true;
});

var app = builder.Build();

//14010215
app.UseHttpsRedirection();//its important
app.UseRouting();










app.UseAuthentication();

//نمیدانم چرا خطا میدهد. میگوید ادداوتورایز را اظافه کن منم بالا اضافه کردم. اگار نمیبیند
//app.UseAuthorization();

/////////////////
#region Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleCQRSwithMediatR.WebApi");
});
#endregion





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}






// Configure the HTTP request pipeline.
//app.MapGrpcService<GreeterService>();
app.MapGrpcService<UserGrpcService>();
//app.MapGrpcService<SMSGrpcService>();
//app.MapGrpcService<EmailGrpcService>();





app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

//app.UseEndpoints(endpoints =>
//{
//    // Communication with gRPC endpoints must be made through a gRPC client.
//    // To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909
//    endpoints.MapGrpcService<UserGrpcService>();
//});
//app.Run();


