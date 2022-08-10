using GrpcNotification.Services;
using Microsoft.EntityFrameworkCore;
//using Notification.Application.Interface.Context;
using Notification.Application.Service.SMS.Commands;
//using Notification.Application.Service.SMS.Queris.Get;
//using Notification.Persistance.Context;
//using Notification.Application.Service.SMS.Commands;
//using SMSService = Notification.Application.Service.SMS.Commands.SMSService;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddScoped<ISMSService, SMSService>();
//builder.Services.AddScoped<IGetSMS, GetSMS>();
//builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();


////For dbcontext14010218
//builder.Services.AddDbContext<DatabaseContext>(item => item.UseSqlServer(builder.Configuration.GetConnectionString("AppDbContext")));
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("cors", policy =>
//    {
//        policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
//    });
//});
////

var app = builder.Build();

//14010215
app.UseHttpsRedirection();
app.UseRouting();


// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
//app.MapGrpcService<SMSGrpcService>();
//app.MapGrpcService<EmailGrpcService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

//app.UseEndpoints(endpoints =>
//{
//    // Communication with gRPC endpoints must be made through a gRPC client.
//    // To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909
//    endpoints.MapGrpcService<SMSGrpcService>();
//});
//app.Run();


