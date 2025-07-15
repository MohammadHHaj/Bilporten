using System.Net.Http.Json;
using Bilporten.Services;
using Shared;

public class BrugereService : IBrugereService
{
    private readonly HttpClient http;

    public BrugereService(HttpClient http)
    {
        http = http;
    }

    public async Task<string?> RegisterAsync(Bruger bruger)
    {
        var res = await http.PostAsJsonAsync("api/Bruger/register", bruger);
        return res.IsSuccessStatusCode ? null : await res.Content.ReadAsStringAsync();
    }

    public async Task<Bruger?> LoginAsync(string email, string password)
    {
        var res = await http.PostAsJsonAsync("api/Bruger/login", new Bruger
        {
            Email = email,
            PasswordHash = password // bruges her som klartekst, hashes på backend
        });

        if (!res.IsSuccessStatusCode)
            return null;

        return await res.Content.ReadFromJsonAsync<Bruger>();
    }
}