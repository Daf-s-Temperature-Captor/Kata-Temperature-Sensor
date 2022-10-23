using DafDev.TemperatureCaptor.Domain.Sensor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DafDev.TemperatureCaptor.Web.UseCases.ModifyTemperatureThresholds;
[Route("api/[controller]")]
[ApiController]
public class ConfigurationController : ControllerBase
{
    private readonly ITemperatureThresholds _temperatureThresholds;
    private readonly ILogger<ConfigurationController> _logger;

    public ConfigurationController(ITemperatureThresholds temperatureThresholds, ILogger<ConfigurationController> logger)
    {
        _temperatureThresholds = temperatureThresholds;
        _logger = logger;
    }

    /// <summary>
    /// modify sensor temperature threshold between cold and warm
    /// temperatures
    /// </summary>
    /// <param name="newTemperature">new cold to warm temperatures threshold</param>
    [HttpGet]
    [Route("fromColdToWarm")]
    public void ModifiyFromColdToWarmThreshold([FromQuery] string newTemperature)
    {
        _logger.LogInformation($"Modified cold to warm temperatures threshold to {newTemperature}");
        if(double.TryParse(newTemperature, out var newTemperatureDouble))
            _temperatureThresholds.ModifiyFromColdToWarmThreshold(newTemperatureDouble);
    }

    /// <summary>
    /// modify sensor temperature threshold between warm and hot
    /// temperatures
    /// </summary>
    /// <param name="newTemperature">new warm to hot temperatures threshold</param>
    [HttpGet]
    [Route("fromWarmToHot")]
    public void ModifiyFromWarmToHotThreshold([FromQuery] string newTemperature)
    {
        _logger.LogInformation($"Modified warm to hot temperatures threshold to {newTemperature}");
        if (double.TryParse(newTemperature, out var newTemperatureDouble))
            _temperatureThresholds.ModifiyFromWarmToHotThreshold(newTemperatureDouble);
    }
}
