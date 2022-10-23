namespace DafDev.TemperatureCaptor.Domain.Sensor;

public class SensorTests
{
    private readonly Sensor _sensor;
    private readonly Mock<ICaptureTemperatures> _captureTemperatureMock = new();

    public SensorTests() => _sensor = new Sensor(_captureTemperatureMock.Object);

    [Theory]
    [MemberData(nameof(InMemoryTestData.GetMinimalTestData), MemberType = typeof(InMemoryTestData))]
    public void ConvertTemperatureToSensorState_WhenReceivingTemperature_ReturnsCorrectSensorState(double temperature, SensorState expectedState)
    {
        //Arrange
        _captureTemperatureMock.Setup(c => c.GetTemperature()).Returns(temperature);

        //Act
        var  actualState = _sensor.ConvertTemperatureToSensorState();

        //Assert
        Assert.Equal(expectedState, actualState);
    }

    [Theory]
    [MemberData(nameof(InMemoryTestData.GetExtensiveTestData), MemberType = typeof(InMemoryTestData))]
    public void ConvertTemperaturesToSensorState_WhenReceivingTemperature_ReturnsTheLastFifteenMeasures(IEnumerable<double> temperatures,
        IEnumerable<SensorState> expectedStates)
    {
        //Arrange
        _captureTemperatureMock.Setup(c => c.GetTemperatures(It.IsAny<int>())).Returns(temperatures);

        //Act
        var actualStates = _sensor.ConvertTemperaturesToSensorState();

        //Assert
        Assert.Equal(expectedStates, actualStates);
    }
}