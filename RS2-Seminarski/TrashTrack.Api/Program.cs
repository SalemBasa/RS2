using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using TrashTrack.Api;
using TrashTrack.Application;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;

var webAppBuilder = WebApplication.CreateBuilder(args);

var connectionStringConfig = webAppBuilder.BindConfig<ConnectionStringConfig>("ConnectionStrings");
var jwtTokenConfig = webAppBuilder.BindConfig<JwtTokenConfig>("JwtToken");

webAppBuilder.Services.AddMapper();
webAppBuilder.Services.AddValidators();
webAppBuilder.Services.AddApplication();
webAppBuilder.Services.AddInfrastructure();
webAppBuilder.Services.AddDatabase(connectionStringConfig);
webAppBuilder.Services.AddAuthenticationAndAuthorization(jwtTokenConfig);
webAppBuilder.Services.AddOther();
webAppBuilder.Services.AddResponseCaching();
webAppBuilder.Services.AddControllers()
                      .AddJsonOptions(options =>
                      {
                          options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                          options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                      });

webAppBuilder.Services.AddHttpContextAccessor()
    .AddScoped<ICurrentUser, CurrentUser>()
    .AddSingleton<ICurrentPrincipalAccessor, CurrentPricipalAccessor>();



webAppBuilder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
webAppBuilder.Services.AddCors(options => options.AddPolicy(
    name: "CorsPolicy",
    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
));

webAppBuilder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

if (webAppBuilder.Environment.IsDevelopment())
{
    webAppBuilder.Services.AddSwagger();
}

var app = webAppBuilder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

string hostname = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "";
string username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest";
string password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest";
string virtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST") ?? "/";

var factory = new ConnectionFactory
{
    HostName = hostname,
    UserName = username,
    Password = password,
    VirtualHost = virtualHost,
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "notification",
                     durable: false,
                     exclusive: false,
                     autoDelete: true,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message.ToString());
    var notification = JsonSerializer.Deserialize<NotificationRabbitUpsertDto>(message);
    using (var scope = app.Services.CreateScope())
    {
        var notificationsService = scope.ServiceProvider.GetRequiredService<INotificationRabbitService>();

        if (notification != null)
        {
            try
            {

                await notificationsService.AddAsync(notification);
            }
            catch (Exception e)
            {

            }
        }
    }
    Console.WriteLine(Environment.GetEnvironmentVariable("Some"));
};
channel.BasicConsume(queue: "notification",
                     autoAck: true,
                     consumer: consumer);



app.Run();