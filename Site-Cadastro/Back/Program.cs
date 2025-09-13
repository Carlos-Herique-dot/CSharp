using Back.Models;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapPost("/cadastro", ([FromForm]Usuarios usuario) =>
{
    Console.WriteLine($"Deu certo, o nome é {usuario.Nome}");
    Console.WriteLine($"Sua senha é {usuario.Senha}");
    return Results.Ok();
}).DisableAntiforgery();

//app.UseHttpsRedirection();

app.Run();

