var builder = WebApplication.CreateBuilder(args);

// Konteynere servisler ekleyin.

var app = builder.Build();

// HTTP istek iþlem hattýný yapýlandýrýn.

app.UseHttpsRedirection();

app.UseCustomExceptionMiddleware();

app.Run();