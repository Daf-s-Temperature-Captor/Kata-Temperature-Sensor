namespace DafDev.TemperatureCaptor.Domain.Sensor;
public interface IDisplayWeather
{
    SensorState DisplaySensorState();
    IEnumerable<SensorState> DisplaySensorStates(int numberOfMeasures = 15);
}
