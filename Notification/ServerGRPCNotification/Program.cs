using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Notification.Application.Interface.Context;
using Notification.Application.Service.Common;
using Notification.Application.Service.SMS.background;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Get;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Persistance.Context;
using NPOI.SS.Formula.Functions;
using ServerGRPCNotification.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();



///
///14010305 for get token from server

builder.Services.AddHttpContextAccessor();


//builder.Services.AddAuthentication("Bearer")
//       .AddJwtBearer("Bearer", options =>
//       {
//           options.Authority = "https://localhost:7254";
//           //options.Authority = "http://localhost:5264";
//           options.TokenValidationParameters = new TokenValidationParameters
//           {
//               ValidateAudience = false
//           };
//       });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           // base-address of your identityserver
           options.Authority = "https://localhost:7254";
           // options.Authority = "http://localhost:5264";

           // audience is optional, make sure you read the following paragraphs
           // to understand your options
           options.TokenValidationParameters.ValidateAudience = false;

           // it's recommended to check the type header to avoid "JWT confusion" attacks
           options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
       });

builder.Services.AddAuthorization();

/// <summary>
/// ///////////////////////////////////////////////////////////////
/// </summary>
/// 


//////////////Add to BackgroundTask 14010225

//builder.Services.AddSingleton<ITaskJob<ResultGetQeueUserSMS>, TaskJob<ResultGetQeueUserSMS>>();

//builder.Services.AddHostedService<MyBackgroundService>();
//builder.Services.AddSingleton<IExecuteBackground, ExecuteBakground>();
builder.Services.AddSingleton<ITaskJobs, TaskJobs>();
///////////////////////////////

//builder.Services.AddGrpc();

builder.Services.AddGrpcReflection();



builder.Services.AddScoped<ISMSService, SMSService>();
builder.Services.AddScoped<IGetSMS, GetSMS>();
builder.Services.AddScoped<IPostSMS, PostSMS>();




//////For dbcontext14010218

//SQL
//builder.Services.AddDbContext<DatabaseContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));

//PostgreSQL
builder.Services.AddDbContext<DatabaseContext>(item => item.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext")));
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
///////////


builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", policy =>
    {
        policy.AllowAnyMethod().
        AllowAnyHeader().
        AllowAnyOrigin().
        WithExposedHeaders("Grpc-Status",
        "Grpc-Message",
        "Grpc-Encoding",
        "Grpc-Accept-Encoding");
    });
});
//




var app = builder.Build();

//14010215
//app.UseHttpsRedirection();
app.UseRouting();

//14010305 for get token from server
app.UseAuthentication();
app.UseAuthorization();

/// ///////////////////////////////



app.UseCors("cors");
//app.UseGrpcWeb();




//app.UseHttpsRedirection();


// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<EmailGrpcsService>();
app.MapGrpcService<SMSGrpcsService>();

//app.UseRouting();

app.MapGrpcReflectionService();



app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.Run();



