using HttpClientService;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupHelper
    {
        public static void RegisterHttpClientService(this IServiceCollection services)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                {
                    return true;
                }
            };
            services
                .AddHttpClient("codecamp")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return handler;
                });
            services.AddSingleton<IHttpService, HttpService>();
            //services.AddSingleton<ClientNameResolver>(sp => ClientNameResolverFactory.CreateClientNameResolver(clientName));
        }
    }
    //public class ClientNameResolver
    //{
    //    public string Name { get; set; }
    //    public ClientNameResolver(string name)
    //    {
    //        Name = name;
    //    }
    //}
    //public class ClientNameResolverFactory
    //{
    //    public static ClientNameResolver CreateClientNameResolver(string name)
    //    {
    //        return new ClientNameResolver(name);
    //    }
    //}
}
