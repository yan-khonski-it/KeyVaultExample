using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using KeyVaultExample;

namespace yan.learning.KeyVaultExample;
public class KeyVaultSimpleExample
{

    private readonly SecretClient secretClient;

    public KeyVaultSimpleExample()
    {
        string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME") ?? throw new Exception("KEY_VAULT_NAME environment variable is not defined.");
        var kvUri = "https://" + keyVaultName + ".vault.azure.net";
        Console.WriteLine($"keyVaultName: {keyVaultName}");
        secretClient = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());
    }

    public async Task ReadSecretExample()
    {
        Console.WriteLine("ReadSecretExample");
        var secretName = "Secret1";
        var secret = await secretClient.GetSecretAsync(secretName);
        PrintSecret(secretName, secret.Value.Value);
        Console.WriteLine("\n\n");
    }

    public async Task ReadAllSecretsExample()
    {
        Console.WriteLine("ReadAllSecretsExample");
        var secretsList = secretClient.GetPropertiesOfSecrets().AsPages().ToList() ?? throw new Exception("Secret list is null.");
        foreach (Azure.Page<SecretProperties> item in secretsList)
        {
            foreach (SecretProperties secretProperties in item.Values)
            {
                // check only secrets with group3 or special secret
                if (secretProperties.ContentType == null && (secretProperties.Name.EndsWith(RandomSuffixGenerator.group3) || secretProperties.Name.Equals("Secret1")))
                {
                    var secret = await secretClient.GetSecretAsync(secretProperties.Name);
                    PrintSecret(secretProperties.Name, secret.Value.Value);
                }
            }
        }
        Console.WriteLine("\n\n");
    }

    private void PrintSecret(string name, string value)
    {
        Console.WriteLine($"secret name: {name}; value: {value}");
    }

    private void CreateSecretsIfEnabled()
    {
        Boolean enabled = false;
        // Enable it once to create secrets.
        if (!enabled)
        {
            throw new Exception("Do not enable it, please.");
        }

        RandomSuffixGenerator randomSuffixGenerator = new();

        int secretsCount = 100;
        for (int i = 0; i < secretsCount; i++)
        {
            string group = randomSuffixGenerator.GetRandomGroup();
            string secretName = $"secret-{i}-{group}";
            secretClient.SetSecret(secretName, "{\"task\": \"some task\"}");
        }
    }
}
