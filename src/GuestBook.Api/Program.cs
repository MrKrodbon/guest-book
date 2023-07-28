using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
<<<<<<< HEAD

=======
>>>>>>> eb9a8ebf6b4312543b32ad251909fa87b5b87176
    x.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("rabbitmq://rabbitmq");

        configurator.ConfigureEndpoints(context);
    });

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

<<<<<<< HEAD
    app.UseSwagger();

=======
>>>>>>> eb9a8ebf6b4312543b32ad251909fa87b5b87176
    app.UseSwaggerUI();
}
else
{
    app.UseDefaultFiles();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
