Console.WriteLine("Encurtador de URL\n");

Console.Write("Digite a URL que deseja encurtar: ");
string? urlLonga = Console.ReadLine();

if (!string.IsNullOrEmpty(urlLonga))
{
    if (IsValidUrl(urlLonga))
    {
       
    }
}
else
{
    Console.WriteLine("URL inválida. Por favor, tente novamente.");
}

static bool IsValidUrl(string url)
{
    return Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
}