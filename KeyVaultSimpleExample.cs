using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace yan.learning.KeyVaultExample;
public class KeyVaultSimpleExample
{
    public async Task RunKeyVaultExample()
    {
        string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME") ?? throw new Exception("KEY_VAULT_NAME environment variable is not defined.");
        Console.WriteLine($"keyVaultName: {keyVaultName}");
        var kvUri = "https://" + keyVaultName + ".vault.azure.net";

        var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

        await client.SetSecretAsync("new-secret", "{\"task\": \"some task\"}");

        var secretName = "Secret1";
        var secret = await client.GetSecretAsync(secretName);
        Console.WriteLine($"secret: {secret.Value.Value}");
    }
}
