namespace yan.learning.KeyVaultExample;

class Program
{
    static async Task Main()
    {
        KeyVaultSimpleExample keyVaultSimpleExample = new KeyVaultSimpleExample();
        await keyVaultSimpleExample.run();
    }
}
