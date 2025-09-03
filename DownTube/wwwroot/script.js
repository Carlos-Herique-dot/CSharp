const enviarBtn = document.getElementById('enviarBtn');
const inputUrl = document.getElementById('inputUrl');
const resposta = document.getElementById('respostaP');

enviarBtn.addEventListener('click', async () =>{
    const url = inputUrl.value;

    if (!url) {
        resposta.textContent = "Por favor, digite uma URL.";
        return;
    }

    const api = "http://localhost:5174/baixar";

    try{
        const response = await fetch(api, {
            method:'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Url: url})
        });

        if (response.ok) {
            const mensagem = await response.text();
            resposta.textContent = `Resposta da API: ${mensagem}`;
            alert("Seu vídeo está sendo baixado");
        }else{
            resposta.textContent = `Erro na requisição: ${error.message}`;
        }
    }
    catch{
        resposta.textContent = `Erro na requisição: ${error.message}`;
        alert(`Erro na requisição: ${error}`);
    }
});