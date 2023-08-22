using AutoMapper;
using InventoryManagement.Extension;
using InventoryManagement.Extension.Exceptions;
using InventoryManagement.Extension.Logger;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureMySqlContext(builder.Configuration);
builder.Services.ConfigureRepository();
builder.Services.ConfigureServiceManager();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



/*if (DbConnectionType != DatabaseConnectionType.Sqlite)
{
    ACSDbConnectionString = builder.Configuration["MyWorldDbConnection"];
    ACSDbServerVersion = ServerVersion.AutoDetect(ACSDbConnectionString);
}*/

//builder.Services.AddDbContext<MyWorldDbContext>(options =>
//{
//    string connectionString = builder.Configuration.GetConnectionString("MyWorldDbConnection");
//    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
//});

//builder.Services.AddCors(options => {
//    options.AddPolicy("Cors", p => {
//        p.AllowAnyHeader()
//        .AllowAnyMethod()
//        .AllowAnyOrigin();
//    });
//});


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public enum DatabaseConnectionType
{
    MySql,
    Sqlite,
    InMemory,
}

public partial class Program
{
    public static DatabaseConnectionType DbConnectionType { get; set; } = DatabaseConnectionType.MySql;
    public static string ACSDbConnectionString { get; set; } = string.Empty;
    public static ServerVersion? ACSDbServerVersion { get; set; } = null;

}