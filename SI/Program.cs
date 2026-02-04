using BL;
using DA;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ?? INYECCIÓN DE DEPENDENCIAS (ESTO ERA LO QUE FALTABA)
builder.Services.AddSingleton<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddSingleton<IVehiculoService, VehiculoService>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
