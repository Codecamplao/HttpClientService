using HttpClientService;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupHelper
    {
        public static void RegisterHttpClientService(this IServiceCollection services)
        {
            //var handler = new HttpClientHandler
            //{
            //    ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            //    {
            //        return true;
            //    }
            //};
            //services
            //    .AddHttpClient("codecamp")
            //    .ConfigurePrimaryHttpMessageHandler(() =>
            //    {
            //        return handler;
            //    });

            ///This way, the HttpClientHandler instance will have the same lifetime as the HttpClient, and the dependency injection system will manage its disposal.
            services.AddScoped<HttpClientHandler>(sp => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                {
                    return true;
                }
            });

            services
                .AddHttpClient("codecamp")
                .ConfigurePrimaryHttpMessageHandler(sp => sp.GetRequiredService<HttpClientHandler>());


            ///This approach creates a new HttpClientHandler instance for each HttpClient, ensuring that the handler is not being reused and disposed of unexpectedly.
            //services
            //    .AddHttpClient("codecamp")
            //    .ConfigurePrimaryHttpMessageHandler(() =>
            //    {
            //        return new HttpClientHandler
            //        {
            //            ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            //            {
            //                return true;
            //            }
            //        };
            //    });


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
