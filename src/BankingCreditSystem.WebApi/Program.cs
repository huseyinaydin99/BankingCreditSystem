using BankingCreditSystem.Application;
using BankingCreditSystem.Persistence;

var builder = WebApplication.CreateBuilder(args);
// Konteynere servisler ekleyin.

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application & Persistence Service Registrations
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var app = builder.Build();


// HTTP istek islem hattina yapilandirin.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomExceptionMiddleware();

app.Run();