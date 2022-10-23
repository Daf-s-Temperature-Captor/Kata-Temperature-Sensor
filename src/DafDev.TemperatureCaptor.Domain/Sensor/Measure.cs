namespace DafDev.TemperatureCaptor.Domain.Sensor;

public class Measure
{
    public double Temperature { get; set; }
    public SensorState State { get; set; }

    public Measure(double temperature, SensorState state)
    {
        Temperature = temperature;
        State = state;
    }
}
