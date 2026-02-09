var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

// Konteynere servisler ekleyin.

var app = builder.Build();


// HTTP istek iþlem hattýný yapýlandýrýn.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTP istek iþlem hattýný yapýlandýrýn.

app.UseHttpsRedirection();

app.UseCustomExceptionMiddleware();

app.Run();