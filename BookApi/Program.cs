using BookApi.Consumers;
using BookApi.Messages;
using BookApi.Models;
using BookApi.Services.BooksService;
using MassTransit;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    //x.AddConsumer<BookConsumer>();
    //x.AddConsumer<BooksConsumer>();
    //x.AddConsumer<BookAddedConsumer>();
    //x.AddConsumer<BookUpdatedConsumer>();
    //x.AddConsumer<BookDeletedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", c =>
        {
            c.Username("admin");
            c.Password("admin");
        });

        //cfg.ReceiveEndpoint("book-queue", e =>
        //{
        //    e.ConfigureConsumer<BookConsumer>(context);
        //    e.ConfigureConsumer<BooksConsumer>(context);
        //    e.ConfigureConsumer<BookAddedConsumer>(context);
        //    e.ConfigureConsumer<BookUpdatedConsumer>(context);
        //    e.ConfigureConsumer<BookDeletedConsumer>(context);

        //    e.Bind("book-exchange");
        //});

        //cfg.ClearSerialization();
        //cfg.UseRawJsonSerializer();
        //cfg.ConfigureEndpoints(context);
    });
});

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

await app.RunAsync();
