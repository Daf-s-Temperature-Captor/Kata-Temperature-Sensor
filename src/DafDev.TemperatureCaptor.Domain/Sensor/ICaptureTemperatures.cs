namespace DafDev.TemperatureCaptor.Domain.Sensor;
public interface ICaptureTemperatures
{
    Task<double> GetTemperature();
    Task<IEnumerable<double>> GetTemperatures(int numberOfMeasures = 15);
}
