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
        yield return new object[] { new List<double> { 60.8,5.2,23,
            60.8,
            5.2,
            23,
            60.8,
            5.2,
            23,
            60.8,
            5.2,
            23,
            60.8,
            5.2,
            28.7,
            60.8,
            5.2,
            23,
            60.8,//This the first measure the test for the extensive data set should upt to the end tof the list
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
        new List<SensorState> { 
            SensorState.Hot,
            SensorState.Hot,
            SensorState.Warm,
            SensorState.Hot,
            SensorState.Cold,
            SensorState.Warm,
            SensorState.Hot,
            SensorState.Cold,
            SensorState.Warm,
            SensorState.Hot,
            SensorState.Warm,
            SensorState.Warm,
            SensorState.Hot,
            SensorState.Cold,
            SensorState.Warm
        } };
    }
}