using System.Collections.Generic;
using ShellApp.Models;

namespace ShellApp.Services
{
    public class MockWeatherService
    {
        private List<Weather> _weathers;

        public MockWeatherService()
        {
           Initialize();
        }

        private void Initialize()
        {
            _weathers = new List<Weather>
            {
                new Weather {Temp = "22", Date = "Sunday 16", Icon = "weather.png"},
                new Weather {Temp = "21", Date = "Monday 17", Icon = "weather.png"},
                new Weather {Temp = "20", Date = "Tuesday 18", Icon = "weather.png"},
                new Weather {Temp = "12", Date = "Wednesday 19", Icon = "weather.png"},
                new Weather {Temp = "17", Date = "Thursday 20", Icon = "weather.png"},
                new Weather {Temp = "20", Date = "Friday 21", Icon = "weather.png"}
            };
        }

        public List<Weather> GetWeathers()
        {
            return _weathers;
        }
    }
}
