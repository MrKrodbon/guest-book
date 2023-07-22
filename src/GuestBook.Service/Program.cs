using GuestBook.Service.Consumers;
using MassTransit;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        string connection = hostContext.Configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<GuestBook.Service.Data.GuestBookContext>(builder => builder.UseSqlServer(connection));


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
