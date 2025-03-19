using ExceptionhandlerAndSerLog.WebAPI;
using ExceptionhandlerAndSerLog.WebAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("./Log/log.txt")
	.CreateLogger();

builder.Services.AddSerilog();//Serilog �al��t�rmak i�in registration i�lemi


builder.Services.AddTransient<UserService>();
builder.Services.AddExceptionHandler<ExceptionHandler>()
	.AddProblemDetails(); // service registration ExceptionHandler

builder.Host.UseSerilog(); //serilog �al��t�rma alan�

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseExceptionHandler();//her api iste�in bir instance olu��turur

app.MapGet("/", (int age, UserService userService) =>
{
	var result = userService.Create(age);
	return result.Item1 ? Results.Ok() : Results.InternalServerError(result.Item2);
});

app.Run();
