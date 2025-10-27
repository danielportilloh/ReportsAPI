namespace Reports.API.Configuration;

public class FakeKeyVaultSecretProvider : ISecretProvider
{
    private readonly IConfiguration _configuration;

    public FakeKeyVaultSecretProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task<string?> GetSecretAsync(string name, CancellationToken cancellationToken = default)
    {
        // Simula obtener el secreto: primero desde configuration (localkeyvault.json),
        // luego desde variable de entorno, y por último fallback a archivo local.
        var secret = _configuration[$"KeyVault:{name}"]
                     ?? Environment.GetEnvironmentVariable(name)
                     ?? "Data Source=reports.db";
        return Task.FromResult<string?>(secret);
    }
}
