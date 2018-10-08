using System.Collections.Generic;
using SongWriter.Web.Models;

namespace SongWriter.Web.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
