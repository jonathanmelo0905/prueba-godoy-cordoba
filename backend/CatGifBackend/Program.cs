

using CatGifBackend.Context;
using CatGifBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// conexion a la bd con entity framework
builder.Services.AddDbContext<CatGifContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnetion"));
    options.UseMySql(builder.Configuration.GetConnectionString("basedatos"),
    new MySqlServerVersion(new Version(8, 0, 21)));
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddHttpClient<CatFactService>();
builder.Services.AddHttpClient<GiphyService>();
builder.Services.AddScoped<HistorialCatGifService>();


#region Config: Cors

// Enable Corsbuilder.Services.AddCors(options =>
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    // Permite cualquier origen
              .AllowAnyMethod()    // Permite cualquier método (GET, POST, etc.)
              .AllowAnyHeader();   // Permite cualquier encabezado
    });
});

#endregion

var app = builder.Build();

// Usar el middleware de CORS
app.UseCors("AllowAll");

//crea laBD si no existe
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CatGifContext>();
    db.Database.EnsureCreated(); // Crea la BD si no existe
}

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
