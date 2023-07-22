using GuestBookService.Consumers;
using GuestBookService.Data;
using GuestBookService.Managers;
using MassTransit;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var sqlConnection = hostContext.Configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<GuestBookDbContext>(builder => builder.UseSqlServer(sqlConnection));

        services.AddScoped<GuestBookManager>();

        services.AddMassTransit(x =>
        {
            x.AddConsumer<GuestBookGetConsumer>();

            x.AddConsumer<GuestBookPostConsumer>();
        });

    })
    .Build();

host.Run();
