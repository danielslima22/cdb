using CDB.API.Application.Handlers;
using CDB.API.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Configuração do Logging (opcional)
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Habilita log no console
builder.Logging.AddDebug();   // Habilita log no Debug (para Visual Studio)

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();

// REGISTRA CQRS (MediatR)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CalcularCdbQueryHandler).Assembly));


// REGISTRA A DEPENDÊNCIA
builder.Services.AddScoped<ICdbService, CdbService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
