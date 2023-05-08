A simple program that reads secrets from Azure Key Vault using the Azure.Identity library.

# Authentication

We use [`DefaultAzureCredential()`](https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) to authenticate the app to Azure Key Vault.

Under the hood, it uses [EnvironmentCredential](https://learn.microsoft.com/en-us/dotnet/api/azure.identity.environmentcredential?view=azure-dotnet).



Create an application in Azure.
Go to Azure Active Directory -> App registrations -> New registration.
![Create new registration](./documents/create_new_Registration.png "create_new_Registration.png")

Redirect URI can be empty.

Add secret to your application.
Copy the secret value to enviromet variable `AZURE_CLIENT_SECRET`.

You need to setup environment variables:
```
AZURE_TENANT_ID
AZURE_CLIENT_ID
AZURE_CLIENT_SECRET
```

![Environment variuables screen](./documents/env_variables.png "env_variables.png")


Configure KeyVault to allow access to your application.
Go to your key vault -> Access policies -> Add Access Policy.
![Add new access policy](./documents/keyvault_access_policies.png "keyvault_access_policies.png")

# Links:

https://learn.microsoft.com/en-us/azure/key-vault/secrets/quick-create-net?tabs=azure-cli

https://stackoverflow.com/questions/75523762/how-to-use-azure-key-vault-from-localhost-using-vs2022