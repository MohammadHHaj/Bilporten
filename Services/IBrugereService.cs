namespace Bilporten.Services;

using Shared;

public interface IBrugereService
{
    Task<string?> RegisterAsync(Bruger bruger);
    Task<Bruger?> LoginAsync(string email, string password);
}
