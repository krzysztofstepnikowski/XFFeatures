using System.Collections.Generic;
using ShellApp.Models;
using ShellApp.Services;

namespace ShellApp.ViewModels
{
    public class WeatherViewModel
    { 
        private readonly MockWeatherService _weatherService;

        public IReadOnlyList<Weather> Weathers => _weatherService.GetWeathers();

        public WeatherViewModel()
        {
            _weatherService = new MockWeatherService();
        }
    }
}
