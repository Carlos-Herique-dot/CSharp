using Back.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MeuCors",
    policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

app.MapPost("/cadastro", ([FromForm] Usuarios usuario) =>
{
    Console.WriteLine($"Deu certo, o nome é {usuario.Nome}");
    Console.WriteLine($"Sua senha é {usuario.Senha}");
    usuario.CadastrarUsuario();

    return Results.Ok();
}).DisableAntiforgery();

app.MapPost("/Login", ([FromForm] Usuarios usuario) =>
{
    usuario.LoginUsuario();
    return Results.Ok();
}).DisableAntiforgery();

app.UseCors("MeuCors");
//app.UseHttpsRedirection();

app.Run();

