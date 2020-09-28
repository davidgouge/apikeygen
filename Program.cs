using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace apikeygen
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("API Access Token Generator.");
            Console.WriteLine();

            Console.Write("Tenant Id: ");
            var tenantId = Console.ReadLine();            
            Console.WriteLine();

            Console.Write("Client Id: ");
            var clientId = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Client Secret: ");
            var clientSecret = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Resource Id: ");
            var resourceId = Console.ReadLine();
            Console.WriteLine();

            var authority = $"https://login.microsoftonline.com/{tenantId}";
            var clientCredential = new ClientCredential(clientId, clientSecret);
            var context = new AuthenticationContext(authority, true);
            var result = await context.AcquireTokenAsync(resourceId, clientCredential);

            Console.WriteLine("Access Token: " + result?.AccessToken);
        }
    }
}
