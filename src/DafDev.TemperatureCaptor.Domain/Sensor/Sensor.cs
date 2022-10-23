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

    public IEnumerable<SensorState> DisplaySensorStates(int numberOfMeasures = 15)
    {
        var temperatures = _temperaturesCaptor.GetTemperatures(numberOfMeasures);
        foreach(var temperature in temperatures)
            yield return ConvertTemperatureToSensorState(temperature);
    }

    public SensorState DisplaySensorState() => ConvertTemperatureToSensorState(_temperaturesCaptor.GetTemperature());

    private SensorState ConvertTemperatureToSensorState(double temperature)
        => temperature < FromColdToWarm ? SensorState.Cold : temperature < FromWarmToHot ? SensorState.Warm : SensorState.Hot;
}
