using DafDev.TemperatureCaptor.Domain.Sensor;
using System.Runtime.CompilerServices;

namespace DafDev.TemperatureCaptor.Domain;

public class InMemoryTestData
{
    public static IEnumerable<object[]> GetMinimalTestData()
    {
        yield return new object[] { 60.8, SensorState.Hot };
        yield return new object[] { 5.2, SensorState.Cold };
        yield return new object[] { 23, SensorState.Warm };
    }

    public static IEnumerable<object[]> GetExtensiveTestData()
    {
        yield return new object[] { new List<double> {
            60.8,
            50.2,
            22,
            108,
            4,
            29,
            70.8,
            9.7,
            23,
            85,
            25.2,
            30,
            788,
            -26,
            35 },
        new List<Measure> {
            new(60.8, SensorState.Hot),
            new(50.2, SensorState.Hot),
            new(22, SensorState.Warm),
            new(108, SensorState.Hot),
            new(4, SensorState.Cold),
            new(29, SensorState.Warm),
            new(70.8, SensorState.Hot),
            new(9.7, SensorState.Cold),
            new(23, SensorState.Warm),
            new(85, SensorState.Hot),
            new(25.2, SensorState.Warm),
            new(30, SensorState.Warm),
            new(788, SensorState.Hot),
            new(-26, SensorState.Cold),
            new(35, SensorState.Warm)
        } };
    }
}