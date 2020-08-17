using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


namespace FlurlBlazor.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            FlurlHttp.Configure(settings =>
            {
                settings.HttpClientFactory = new BlazorHttpClientFactory();
            });

            await builder.Build().RunAsync();
        }
    }
}
