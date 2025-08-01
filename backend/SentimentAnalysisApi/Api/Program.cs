using Api.BackgroundServices;
using Api.Hubs;
using Api.Services;
using Application;
using Domain.Services;
using Infra.AI;
using Infra.Data;
using Infra.Data.Base;
using Infra.MessageBus;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddOpenApi();
builder.Services.AddIoCData(builder.Configuration);
builder.Services.AddIoCMessageBus(builder.Configuration);
builder.Services.AddIoCAi(builder.Configuration);
builder.Services.AddIoCApplication(builder.Configuration);
builder.Services.AddScoped<IClientNotificationService, ClientNotificationService>();
builder.Services.AddCors(op => op.AddDefaultPolicy(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
builder.Services.AddHostedService<AnalyzeProductReviewConsumer>();

var app = builder.Build();
app.MapOpenApi();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ProductReviewedHub>("/admin/notifications");

var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
scope.Dispose();

app.Run();
