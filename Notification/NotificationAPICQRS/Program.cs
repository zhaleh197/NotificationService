using Cqrs.Hosts;
//using MailKit;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Notification.Application.ApplicationbyMediator.Common;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.Common.Behaviors;
using Notification.Application.ApplicationbyMediator.Common.Notification.EmailNotification;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.AddReadUser;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Delete;
using Notification.Application.ApplicationbyMediator.UserApplication.Queries.GetById;
using Notification.Application.Interface.Context;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.WriteRepository.Email.Commands;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Get;
using Notification.Application.Service.User.Enroll;
using Notification.Persistance.Context;
using NotificationAPICQRS;
using System.Reflection;
using Notification.Application.Service.User.Proj; 
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Application.Service.WriteRepository.SMS.Queris.PostQ;
using Notification.Application.Service.WriteRepository.SMS.Queris.GetQ;
using Notification.Application.Service.User.Doc;
using Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.GetQSMS;
using Microsoft.IdentityModel.Tokens;
using Notification.Application.Service.WriteRepository.User.Kat;
using Notification.Application.Service.WriteRepository.User.Kat.SarKhat;
using Notification.Application.Service.Email.Queris.Get;
using Notification.Application.Service.Notification.Commands;
using Notification.Application.Service.Notification.Queris.Get;
using Notification.Application.Service.WriteRepository.User.Transaction;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Kafka;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.DocReadUser;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.KhatReadUser;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.DeleteDoc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Doc.AddDoc;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.AddKhat;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands.Khat.DeleteKhat;
using Notification.Application.ApplicationbyMediator.UserApplication.BackgroundWorker.TransactionReadUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication("Bearer")
       .AddJwtBearer("Bearer", options =>
       {
           options.Authority = "https://localhost:7254";
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateAudience = false
           };
       });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Test Behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
//builder.Services.AddTransient(typeof(IRequestPreProcessor<>), typeof(RequestPreProcessor<>));
//builder.Services.AddTransient(typeof(IRequestPostProcessor<>), typeof(RequestPostProcessor<>));




/// ////////////////////////////////////



/////////
///
var conectionString = "Data Source=.;Initial Catalog=SMSServiceDB;Integrated Security=true;MultipleActiveResultSets=true";
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(conectionString,
    b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName));
});
/////////
///

/// DB

#region IOC

builder.Services.AddScoped<IDatabaseContext>(provider => provider.GetService<DatabaseContext>());

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
/////////


//builder.Services.AddControllers();
#endregion
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
///////
/// <summary>
/// 
/// 
/// 
/// </summary>
var app = builder.Build();

app.UseRouting(); 

app.UseAuthentication();
app.UseAuthorization();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



/////////////////
#region Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SampleCQRSwithMediatR.WebApi");
});
#endregion
//////////////
///  

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
