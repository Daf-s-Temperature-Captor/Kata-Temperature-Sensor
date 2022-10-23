namespace DafDev.TemperatureCaptor.Domain.Sensor;
public interface IDisplayWeather
{
    Task<Measure> DisplaySensorState();
    Task<IEnumerable<Measure>> DisplaySensorStates(int numberOfMeasures = 15);
}
