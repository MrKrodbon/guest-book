using GuestBookService;
using GuestBookService.Consumers;
using GuestBookService.Managers;
using MassTransit;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        var sqlConnection = Environment.GetEnvironmentVariable("DEFAULT_CONNECTION");

        services.AddDbContext<GuestBookContext>(builder => builder.UseSqlServer(sqlConnection));

        services.AddScoped<GuestBookManager>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<GuestBookGetConsumer>();

            x.AddConsumer<GuestBookPostConsumer>();

            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("rabbitmq://rabbitmq");
                configurator.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();
