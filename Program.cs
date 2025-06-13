using Bilporten;
using Bilporten.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Tilføj HttpClient (deles af alle services)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5012") // din backend-URL
});

// Lokal storage
builder.Services.AddBlazoredLocalStorage();

// Services
builder.Services.AddScoped<IBrugereService, BrugereService>();

await builder.Build().RunAsync();