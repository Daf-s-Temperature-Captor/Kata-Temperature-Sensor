using System.Runtime.CompilerServices;

namespace DafDev.TemperatureCaptor.Domain.Sensor;

public class SensorTests
{
    private readonly Sensor _sensor;
    private readonly Mock<ICaptureTemperatures> _captureTemperatureMock = new();

    public SensorTests() => _sensor = new Sensor(_captureTemperatureMock.Object);

    [Theory]
    [MemberData(nameof(InMemoryTestData.GetMinimalTestData), MemberType = typeof(InMemoryTestData))]
    public async Task ConvertTemperatureToSensorState_WhenReceivingTemperature_ReturnsCorrectSensorState(double temperature, SensorState expectedState)
    {
        //Arrange
        _captureTemperatureMock.Setup(c => c.GetTemperature()).ReturnsAsync(temperature);

        //Act
        var  actualState = await _sensor.DisplaySensorState();

        //Assert
        Assert.Equal(expectedState, actualState);
    }

    [Theory]
    [MemberData(nameof(InMemoryTestData.GetExtensiveTestData), MemberType = typeof(InMemoryTestData))]
    public async Task  ConvertTemperaturesToSensorState_WhenReceivingTemperature_ReturnsTheLastFifteenMeasures(IEnumerable<double> temperatures,
        IEnumerable<SensorState> expectedStates)
    {
        //Arrange
        _captureTemperatureMock.Setup(c => c.GetTemperatures(It.IsAny<int>())).ReturnsAsync(temperatures);

        //Act
        var actualStates = await _sensor.DisplaySensorStates();

        //Assert
        Assert.Equal(expectedStates, actualStates);
    }
}