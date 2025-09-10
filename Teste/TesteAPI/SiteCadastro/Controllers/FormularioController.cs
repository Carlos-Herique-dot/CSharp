using Microsoft.AspNetCore.Mvc;
using FormularioApi.Models;

[Route("api/[controller]")]
[ApiController]
public class FormularioController : ControllerBase
{
    [HttpPost]
    public IActionResult ReceberDados([FromBody] DadosFormulario dados)
    {
        if (dados == null)
        {
            return BadRequest("O corpo da requisição está vazio.");
        }
        Console.WriteLine($"Dados recebidos: Nome = {dados.Nome}, Senha = {dados.Senha}");

        return Ok("Dados recebidos com sucesso.");
    }
}