const form = document.getElementById("form-cadastro");

const senha1 = document.getElementById("senha");
const senha2 = document.getElementById("senhaRepete");
const lblRepete = document.getElementById("lblRepete");

senha2.addEventListener('input', (evento) =>{
    if (senha2.value === '') {
        lblRepete.style.color = "black";
    }
    else if (senha1.value === senha2.value) {
        lblRepete.style.color = "green";
    }
    else{
        lblRepete.style.color = "red";
    }
});


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