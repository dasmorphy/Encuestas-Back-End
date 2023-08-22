using Microsoft.EntityFrameworkCore;
using apiprueba;
using OfficeOpenXml;
using apiprueba.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(
    opciones => opciones.UseSqlServer("name=DefaultConnection")
 );

// Configurar el contexto de licencia de EPPlus
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

builder.Services.AddCors(opciones => opciones.AddPolicy("AllowWebApp", 
                         builder => builder.AllowAnyHeader()
                                           .AllowAnyMethod()
                                           .AllowAnyOrigin()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrega la capacidad de recibir archivos
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
builder.Services.AddMvc(options =>
{
    options.MaxModelBindingCollectionSize = int.MaxValue;
});
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Services.AddSession(options =>
{
    // Configuración de las opciones de sesión
    options.Cookie.Name = "SessionProject";
    options.IdleTimeout = TimeSpan.FromSeconds(15);
    options.Cookie.IsEssential = true;
});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IModuloPreguntasService, ModuloPreguntasService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();

//}
app.UseSession();
app.UseCors("AllowWebApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
