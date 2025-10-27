namespace Reports.API.Configuration;

public interface ISecretProvider
{
    Task<string?> GetSecretAsync(string name, CancellationToken cancellationToken = default);
}