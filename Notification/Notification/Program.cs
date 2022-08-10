using AutoMapper;
using CorePush.Apple;
using CorePush.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Notification.Application.Interface.Context;
using Notification.Application.Service.WriteRepository.Email.Commands;
using Notification.Application.Service.Email.Queris.Get;
using Notification.Application.Service.Notification.Commands;
using Notification.Application.Service.Notification.Queris.Get;
using Notification.Application.Service.SMS.background;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Get;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Persistance.Context;
using NotificationAPI;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



//////////////Add to BackgroundTask 14010225
//builder.Services.AddScoped<IScopedService,MyScopedService>():


//builder.Services.AddHostedService<MyBackgroundService>();

//builder.Services.AddSingleton<IExecuteBackground, ExecuteBakground>();

///////////////////////////////


builder.Services.AddControllers();


/////////////////////////////////get tohen identity server


////// //////////////////azita-token-14010227

builder.Services.AddAuthentication("Bearer")
       .AddJwtBearer("Bearer", options =>
       {
           options.Authority = "https://localhost:7254";
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateAudience = false
           };
       });
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//                .AddJwtBearer("Bearer", options =>
//                {
//                    options.Authority = "https://localhost:7254";//url Identityserver

//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateAudience = false
//                    };
//                });
//////


//// adds an authorization policy to make sure the token is for scope 'api1'
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ApiScope", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim("scope", "scope2");
//    });
//});
///////////////////////////////////////////////////



/// DatabaseContext
string contectionstring = "Data Source=.; Initial Catalog= NotificationAPI ; Integrated Security=true ; MultipleActiveResultSets=True";
//builder.Services.AddSqlServer<DatabaseContext>(contectionstring);
builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(contectionstring));

builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();

/// //sms
/// builder.Services.AddScoped<ITaskJob<T>, TaskJob<T>>(); 
builder.Services.AddScoped<IGetSMS, GetSMS>();
builder.Services.AddScoped<ISMSService, SMSService>();
//builder.Services.AddScoped<IPostSMS, PostSMS>();




////


///mail
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddTransient<IGetNotification, GetNotification>();
//

//notification
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddHttpClient<FcmSender>();
builder.Services.AddHttpClient<ApnSender>();


// Configure strongly typed settings objects
var appSettingsSection = builder.Configuration.GetSection("FcmNotification");
builder.Services.Configure<FcmNotificationSetting>(appSettingsSection);
//




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/// <summary>
/// 
/// 
/// 
/// </summary>

var app = builder.Build();




app.UseRouting();

//app.UseAuthentication();
//app.UseAuthorization();
app.UseAuthentication();
app.UseAuthorization();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


/// //////////////////azita-token-14010227
app.MapControllers();
//app.MapControllers().RequireAuthorization("ApiScope");
/////////////////////////////////////////////////

app.Run();
