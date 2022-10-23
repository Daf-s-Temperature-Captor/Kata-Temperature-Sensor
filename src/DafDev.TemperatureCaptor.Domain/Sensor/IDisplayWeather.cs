namespace DafDev.TemperatureCaptor.Domain.Sensor;
public interface IDisplayWeather
{
    Task<SensorState> DisplaySensorState();
    Task<IEnumerable<SensorState>> DisplaySensorStates(int numberOfMeasures = 15);
}
