using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMassTransit(cfg =>
{
    var assembly = typeof(Program).Assembly;

    cfg.SetKebabCaseEndpointNameFormatter();
    cfg.SetInMemorySagaRepositoryProvider();

    cfg.AddConsumers(assembly);
    cfg.AddSagas(assembly);
    cfg.AddSagaStateMachines(assembly);
    cfg.AddActivities(assembly);

    cfg.UsingRabbitMq((context, rabbitCfg) =>
    {
        rabbitCfg.Host("localhost", "/", h =>
        {
            h.Username("admin");
            h.Password("admin");
        });

        rabbitCfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
