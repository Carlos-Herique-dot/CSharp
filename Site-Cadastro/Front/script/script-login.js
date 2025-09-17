const url = "http://localhost:5070/login";
const formLogin = document.getElementById("form-login");

formLogin.addEventListener("submit", async (evento) =>
{
    evento.preventDefault();
    const dados = new FormData(formLogin);
    
    try 
    {
        const resposta = await fetch(url,
            {
                method: 'POST',
                body: dados
            });
        if (!resposta.ok) {
            alert("Erro ao logar");
        } 
        else{
            alert("Enviou");
        }
    } 
    catch (error) 
    {
        alert("Erro ao acessar API");
    }
});