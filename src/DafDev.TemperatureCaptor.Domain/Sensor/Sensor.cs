namespace DafDev.TemperatureCaptor.Domain.Sensor;
public class Sensor : IDisplayWeather, ITemperatureThresholds
{
    private readonly ICaptureTemperatures _temperaturesCaptor;

    public Sensor(ICaptureTemperatures temperaturesCaptor)
    {
        _temperaturesCaptor = temperaturesCaptor;
        FromColdToWarm = 22;
        FromWarmToHot = 40;
    }

    public double FromColdToWarm { get; set; }
    public double FromWarmToHot { get; set; }

    public IEnumerable<SensorState> ConvertTemperaturesToSensorState()
    {
        return new List<SensorState>();
    }

    public SensorState ConvertTemperatureToSensorState()
    {
        var temperature = _temperaturesCaptor.GetTemperature();

        return temperature < FromColdToWarm ? SensorState.Cold : temperature < FromWarmToHot ? SensorState.Warm : SensorState.Hot;
    }
}
