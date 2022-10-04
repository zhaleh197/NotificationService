using ApacheKafkaConsumerDemo;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Events;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.GetQSMS;
using Notification.Application.Interface.Context;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Application.Service.WriteRepository.SMS.Queris.GetQ;
using Notification.Application.Service.WriteRepository.User.Kat;
using Notification.Persistance.Context;

var builder = WebApplication.CreateBuilder(args);

var conectionString = "Data Source=.;Initial Catalog=SMSServiceDB;Integrated Security=true;MultipleActiveResultSets=true";
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(conectionString,
    b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName));
});
// Add services to the container.
builder.Services.AddScoped<IDatabaseContext>(provider => provider.GetService<DatabaseContext>());
#region Mongo Singleton Injectio
var mongoClient = new MongoClient("mongodb://localhost:27017");
var mongoDatabase = mongoClient.GetDatabase("NotificationCQRS");
builder.Services.AddSingleton(mongoDatabase);
#endregion


builder.Services.AddSingleton(typeof(ChannelQueue<>));

builder.Services.AddSingleton<IHostedService, ApacheKafkaConsumerService>();

builder.Services.AddScoped<ISMSService, SMSService>();//send sms


builder.Services.AddHostedService<CheckQueueSMSWorker>();
builder.Services.AddSingleton(typeof(ChannelQueue<SMSAddedinQueue>));


builder.Services.AddScoped<IKhat, Khat>();

builder.Services.AddScoped<IPostSMS, PostSMS>();
builder.Services.AddScoped<IGetQ, GetQ>();

builder.Services.AddScoped<ReadSMSUser>();



builder.Services.AddScoped<ReadUserDoc>();
builder.Services.AddScoped<ReadUserKhat>();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

