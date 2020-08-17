using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using FlurlBlazor.Client.ApiConstants;
using FlurlBlazor.Shared;
using LanguageExt;
using static LanguageExt.Prelude;

namespace FlurlBlazor.Client.ApiServices
{
    public static class ApiFunctions
    {
        public static TryAsync<List<WeatherForecast>> TryGetWeatherForecasts()
            => TryAsync(async () => await GetWeatherForecastsAsync()
                .ConfigureAwait(false));

        public static async Task<List<WeatherForecast>> GetWeatherForecastsAsync()
            => await WeatherForecasts.GetUrl
                .GetJsonAsync<List<WeatherForecast>>()
                .ConfigureAwait(false);
    }
}