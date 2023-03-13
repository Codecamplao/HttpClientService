using HttpClientService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupHelper
    {
        public static void RegisterHttpClientService(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddSingleton<IHttpService, HttpService>();
        }
    }
}
