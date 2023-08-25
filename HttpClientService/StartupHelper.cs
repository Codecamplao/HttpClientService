using HttpClientService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;

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
        }
    }
}
