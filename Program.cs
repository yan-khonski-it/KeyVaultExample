namespace yan.learning.KeyVaultExample;

class Program
{
    static void Main()
    {
        KeyVaultSimpleExample keyVaultSimpleExample = new KeyVaultSimpleExample();

        // Use this to populate secrets for futher usages.
        // keyVaultSimpleExample.CreateSecretsIfEnabled();

        Task res1 = keyVaultSimpleExample.ReadSecretExample();
        Task res2 = keyVaultSimpleExample.ReadAllSecretsExample();

        Task.WaitAll(res1, res2);
    }
}
