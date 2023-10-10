using Microsoft.EntityFrameworkCore;
using apiprueba;
using OfficeOpenXml;
using apiprueba.Services;
using System.Globalization;
using apiprueba.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Habilitar el comportamiento legacy de Npgsql. Se habilita unicamente para PostGreSql por el formato de fecha en base
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(
    //opciones => opciones.UseSqlServer("name=DefaultConnection")
    opciones => opciones.UseNpgsql(builder.Configuration.GetConnectionString("PostGreSqlConnection"))
 );

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US");
    options.SupportedCultures = new List<CultureInfo> { new CultureInfo("en-US") };
    options.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en-US") };
});


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
builder.Services.AddScoped<IHashPasswordService, HashPasswordService>();
builder.Services.AddScoped<IEvaluacionService, EvaluacionServiceImpl>();


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
