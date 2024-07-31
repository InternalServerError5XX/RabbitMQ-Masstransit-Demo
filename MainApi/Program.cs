using MainApi;
using MainApi.Services.BookConsumerService;
using MainApi.Services.BooksConsumerService;
using MainApi.Services.StoreService;
using MassTransit;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IStoreService, StoreService>();
builder.Services.AddScoped<IBookConsumerService, BookConsumerService>();
builder.Services.AddScoped<IBooksConsumerService, BooksConsumerService>();

builder.Services.AddHttpClient("books-api", c =>
{
    c.BaseAddress = new Uri("https://localhost:7150/api/books/");
});

builder.Services.AddMassTransit(x =>
{
    var assembly = typeof(Program).Assembly;

    x.SetKebabCaseEndpointNameFormatter();
    x.SetInMemorySagaRepositoryProvider();

    x.AddConsumers(assembly);
    x.AddSagas(assembly);
    x.AddSagaStateMachines(assembly);
    x.AddActivities(assembly);

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("admin");
            h.Password("admin");
        });

       cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1_api", new OpenApiInfo { Title = "Main Api", Version = "v1" });
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (docName == "v1_api")
            return apiDesc.RelativePath.Contains("api") && !apiDesc.RelativePath.Contains("books");

        return false;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1_api/swagger.json", "Books Consumer API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
