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

    public async Task<IEnumerable<SensorState>> DisplaySensorStates(int numberOfMeasures = 15)
    {
        var temperatures = await _temperaturesCaptor.GetTemperatures(numberOfMeasures);
        var states = new List<SensorState>();
        foreach(var temperature in temperatures)
            states.Add(ConvertTemperatureToSensorState(temperature));
        return states;
    }

    public async Task<SensorState> DisplaySensorState() => ConvertTemperatureToSensorState(await _temperaturesCaptor.GetTemperature());

    private SensorState ConvertTemperatureToSensorState(double temperature)
        => temperature < FromColdToWarm ? SensorState.Cold : temperature < FromWarmToHot ? SensorState.Warm : SensorState.Hot;
}
