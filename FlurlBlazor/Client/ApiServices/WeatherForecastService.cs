using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;
using FlurlBlazor.Client.ApiConstants;
using FlurlBlazor.Shared;

namespace FlurlBlazor.Client.ApiServices
{
    public interface IWeatherForecastService
    {
        Task<List<WeatherForecast>> Get();
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        public async Task<List<WeatherForecast>> Get()
            => await WeatherForecasts.GetUrl
                .GetJsonAsync<List<WeatherForecast>>()
                .ConfigureAwait(false);
    }
}