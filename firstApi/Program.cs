using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Service.DataContext;
using Service.Interfaces;
using Service.Services;
using System.Net;
using System;
using firstApi.CustomMiddlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers() ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("PostgresqlConnection")
    ));

builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IStaffRepository, StaffRepository>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<CheckTokenMiddleware>();

app.Map("/kamoliddin", () =>
    {
    return "Hello kamoliddin";
});
/*app.Use(async (context, next) =>
{
    if (context.Request.Path == "/salohiddin")
    {
        await context.Response.WriteAsync("Hello salohiddin");
    }
    else
    {
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync("Hello guest");
    }
    await next.Invoke();
});*/
//app.UseMiddleware<ExceptionHandlerMiddleware>();
app.Run();
