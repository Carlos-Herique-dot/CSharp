const form = document.getElementById("form-cadastro");

form.addEventListener("submit", async (evento) =>
{
    evento.preventDefault();

    const dados = new FormData(form);

    const url = "http://localhost:5070/cadastro";

    try 
    {
        const response = await fetch(url, {
            method: 'POST',
            body: dados
        });

        if (!response.ok) {
            alert("Erro ao enviar");
            
        }
        else{
            alert("Formulário enviado");
        }
    } 
    catch (error) 
    {
        alert(`Tudo errado ${error.message}`);
    }
});