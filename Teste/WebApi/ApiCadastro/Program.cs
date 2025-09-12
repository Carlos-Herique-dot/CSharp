using ApiCadastro.Classes;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/savar-usuario", (Usuarios usuarios) =>
{
    Console.WriteLine($"Nome: {usuarios.Nome} - Senha: {usuarios.Senha}");
    return Results.Ok("Usuário salvo com sucesso!");
});

app.UseHttpsRedirection();


app.Run();


public class Usuarios
{
        public string Nome { get; set; }    
        public string Senha { get; set; }
}