using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    /// <summary>
    /// Retorna informações climáticas para uma cidade específica.
    /// </summary>
    /// <param name="city">Nome da cidade para obter o clima.</param>
    /// <returns>Informações climáticas no formato JSON.</returns>
    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        var weatherData = await _weatherService.GetWeatherAsync(city);
        return Ok(weatherData);
    }
}
