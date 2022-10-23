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

    public async Task<IEnumerable<Measure>> DisplaySensorStates(int numberOfMeasures = 15)
    {
        var temperatures = await _temperaturesCaptor.GetTemperatures(numberOfMeasures);
        var states = new List<Measure>();
        foreach(var temperature in temperatures)
            states.Add(new(temperature, ConvertTemperatureToSensorState(temperature)));
        return states;
    }

    public async Task<Measure> DisplaySensorState()
    {
        var temperature = await _temperaturesCaptor.GetTemperature();
        return new (temperature, ConvertTemperatureToSensorState(temperature));
    }
    public void ModifiyFromColdToWarmThreshold(double newTemperature) => FromColdToWarm = newTemperature;

    public void ModifiyFromWarmToHotThreshold(double newTemperature) => FromWarmToHot = newTemperature;

    private SensorState ConvertTemperatureToSensorState(double temperature)
        => temperature < FromColdToWarm ? SensorState.Cold : temperature < FromWarmToHot ? SensorState.Warm : SensorState.Hot;

}
