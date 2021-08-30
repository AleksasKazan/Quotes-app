using System;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace QuotesApp
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            //var userName = "alexk";
            //var passwd = "tokadi9823@fxseller.com";
            var services = new ServiceCollection();

            //services.AddTransient<HttpClient>();

            services.AddHttpClient<IFavqsClient, FavqsClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://favqs.com");
                httpClient.DefaultRequestHeaders.Add("Authorization", "Token token=9173e597a7c1fab6a14e9e4866d6e6a0");
            });

            return services.BuildServiceProvider();
        }
    }
}
