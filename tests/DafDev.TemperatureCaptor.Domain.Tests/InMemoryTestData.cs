using DafDev.TemperatureCaptor.Domain.Sensor;

namespace DafDev.TemperatureCaptor.Domain;

public class InMemoryTestData
{
    public static IEnumerable<object[]> GetMinimalTestData()
    {
        yield return new object[] { 60.8, SensorState.Hot };
        yield return new object[] { 5.2, SensorState.Cold };
        yield return new object[] { 23, SensorState.Warm };
    }
}