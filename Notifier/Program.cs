using MassTransit;
using Microsoft.EntityFrameworkCore;
using Notifier;
using Notifier.Common.Inbox;
using Notifier.Common.Persistence;
using Notifier.Features.Sms;
using PayamakCore;
using System.Reflection;
using sziarati.Notifier.Features.SMS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettings>(builder.Configuration);
var configs = builder.Configuration.Get<AppSettings>();

builder.Services.AddDbContext<NotifierDbContext>(options => {

    options.UseMongoDB(configs.Connection.Host, configs.Connection.DatabaseName);
    });

DependencyInjections.RegisterMessageBroker(builder.Services, builder.Configuration);
DependencyInjections.RegisterMediatR(builder.Services);

builder.Services.AddHostedService<InboxProcessBackGroundService>();

builder.Services.AddScoped<SMSService>();
builder.Services.AddScoped<InboxService>();

builder.Services.AddPayamakService();
builder.Services.AddScoped<ISMSProvider, FaraPayamakProvider>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
