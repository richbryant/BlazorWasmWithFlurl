using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using FlurlBlazor.Client.ApiConstants;
using FlurlBlazor.Shared;

namespace FlurlBlazor.Client.ApiServices
{
    public static class ApiFunctions
    {
        public static async Task<List<WeatherForecast>> GetWeatherForecasts()
            => await WeatherForecasts.GetUrl
                .GetJsonAsync<List<WeatherForecast>>()
                .ConfigureAwait(false);
    }
}