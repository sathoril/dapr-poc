var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "You called Microservice 1!");
app.MapGet("/CallMicroservice2", async () =>
{
    var response = string.Empty;
    
    try
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://second-api:80/");
        var httpResponse = await httpClient.GetAsync("/");
        httpResponse.EnsureSuccessStatusCode();
        response = await httpResponse.Content.ReadAsStringAsync();
    }
    catch (Exception e)
    {
        return "Ocorreu um erro chamando Microservico 2";
    }

    return response;
});


app.Run();
