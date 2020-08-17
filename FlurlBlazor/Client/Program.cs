using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using FlurlBlazor.Client.ApiServices;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace FlurlBlazor.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            FlurlHttp.Configure(settings => settings.HttpClientFactory = new BlazorHttpClientFactory());

            builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

            await builder.Build().RunAsync();
        }
    }
}
