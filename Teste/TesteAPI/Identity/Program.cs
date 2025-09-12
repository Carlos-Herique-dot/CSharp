using ApiIdentityEndpoint.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(""));


var app = builder.Build();


app.UseHttpsRedirection();


app.Run();

