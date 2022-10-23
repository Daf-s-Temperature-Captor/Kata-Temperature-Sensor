namespace DafDev.TemperatureCaptor.Domain.Sensor;
public interface IDisplayWeather
{
    SensorState ConvertTemperatureToSensorState();
    IEnumerable<SensorState> ConvertTemperaturesToSensorState();
}
