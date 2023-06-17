var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello from Microservice 2!");
app.MapGet("/CallMicroservice1", async () =>
{
    var response = string.Empty;
    
    try
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://first-api:80/");
        var httpResponse = await httpClient.GetAsync("/");
        httpResponse.EnsureSuccessStatusCode();
        response = await httpResponse.Content.ReadAsStringAsync();
    }
    catch (Exception e)
    {
        return "Ocorreu um erro chamando Microservico 1";
    }

    return response;
});

app.Run();
