using DafDev.TemperatureCaptor.Domain.Sensor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DafDev.TemperatureCaptor.Web.UseCases.DisplayTemperature;
[Route("api/[controller]")]
[ApiController]
public class TemperatureController : ControllerBase
{
    private readonly IDisplayWeather _displayWeather;
    private ILogger<TemperatureController> _logger;

    public TemperatureController(IDisplayWeather displayWeather, ILogger<TemperatureController> logger)
    {
        _displayWeather = displayWeather;
        _logger = logger;
    }

    /// <summary>
    /// Gets current temperature
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("")]
    public async Task<Measure> GetTemperature()
    {
        var  measure = await _displayWeather.DisplaySensorState();
        _logger.LogInformation($"Got {measure.Temperature} °C which is {measure.State}. ");
        return measure;
    }

    /// <summary>
    /// Display last X number of recoreded temperatures
    /// </summary>
    /// <param name="numberOfMeasures"> number of measures asked</param>
    /// <returns></returns>
    [HttpGet]
    [Route("temperatures")]
    public async Task<IEnumerable<Measure>> GetTemperatures([FromQuery] int numberOfMeasures = 15)
    {
        _logger.LogInformation($"Get last {numberOfMeasures} measures");
        return await _displayWeather.DisplaySensorStates(numberOfMeasures);
    }
}
