using YoutubeExplode;
using Xabe.FFmpeg;
using YoutubeExplode.Videos.Streams;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(policy => policy.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapPost("/baixar", async (DadosDoForm dados) =>
{
    var youtube = new YoutubeClient();

    string? videoUrl = dados.Url;

    try
    {
        var video = await youtube.Videos.GetAsync(videoUrl);
        Console.WriteLine(videoUrl);

        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
        Console.WriteLine("passou pelo stramManifest");
        var videoStreamInfo = streamManifest.GetVideoOnlyStreams().GetWithHighestVideoQuality();
        var audioStreamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
        if (videoStreamInfo != null && audioStreamInfo != null)
        {
            string videoFilePath = "video_temp.mp4";
            string audioFilePath = "audio_temp.mp4";

            Console.WriteLine("Baixando stream de vídeo...");
            await youtube.Videos.Streams.DownloadAsync(videoStreamInfo, videoFilePath);

            Console.WriteLine("Baixando stream de áudio...");
            await youtube.Videos.Streams.DownloadAsync(audioStreamInfo, audioFilePath);

            Console.WriteLine("Dowload dos arquivos separados concluídos com sucesso!");

            var autputFilePath = "video_final.mp4";

            IConversion conversion = await FFmpeg.Conversions.New();
            conversion.AddStream(VideoStream);

            IStream videoStream = await FFmpeg.GetMediaInfo(videoFilePath);

            IStream audioStream = await FFmpeg.GetStreamInfo(audioFilePath);
        conversion.AddStream(audioStream);

        // 4. Define o caminho do arquivo de saída
        conversion.SetOutput(autputFilePath);

        Console.WriteLine("Iniciando a combinação de áudio e vídeo...");

        // Opcional: define um manipulador de eventos para acompanhar o progresso
        conversion.OnProgress += (sender, eventArgs) =>
        {
            Console.WriteLine($"Progresso: {eventArgs.Percent}%");
        };

        // 5. Executa a conversão
        await conversion.Start();


        }
        Console.WriteLine($"Download concluído com sucesso!");
    
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class DadosDoForm
{
    public string? Url { get; set; }
}