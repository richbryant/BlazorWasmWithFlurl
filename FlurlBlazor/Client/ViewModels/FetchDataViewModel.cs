using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlurlBlazor.Client.ApiServices;
using FlurlBlazor.Shared;
using LanguageExt;
using ReactiveUI;
using RxUnit = System.Reactive.Unit;

namespace FlurlBlazor.Client.ViewModels
{
    public class FetchDataViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<List<WeatherForecast>> _forecasts;
        private readonly TryAsync<List<WeatherForecast>> _protectedFunction;

        public List<WeatherForecast> Forecasts => _forecasts.Value;
        public ReactiveCommand<RxUnit, List<WeatherForecast>> LoadForecasts { get; }

        public FetchDataViewModel(TryAsync<List<WeatherForecast>> protectedFunction = null)
        {
            _protectedFunction = protectedFunction ?? ApiFunctions.TryGetWeatherForecasts();

            LoadForecasts = ReactiveCommand.CreateFromTask(LoadWeatherForecastsAsync);

            _forecasts = LoadForecasts.ToProperty(this, x => x.Forecasts, scheduler: RxApp.MainThreadScheduler);
        }

        private async Task<List<WeatherForecast>> LoadWeatherForecastsAsync()
        {
            var list = new List<WeatherForecast>();
            await _protectedFunction.Match(
                Succ: x => list.AddRange(x),
                Fail: x => Console.WriteLine(x.Message));

            return list;
        }
    }
}