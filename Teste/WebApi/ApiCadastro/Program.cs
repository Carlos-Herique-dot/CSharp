using Microsoft.AspNetCore.Mvc;
using ApiCadastro.Classes;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MeuCors", builder =>
    {
        builder.WithOrigins("http://localhost:5028").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
}); 


var app = builder.Build();

app.UseCors("MeuCors");

app.MapPost("/salvar-usuario", ([FromForm]Usuarios usuarios) =>
{
    return usuarios;   
     
}).DisableAntiforgery();

//app.UseHttpsRedirection();


app.Run();


