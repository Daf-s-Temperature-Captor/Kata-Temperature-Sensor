namespace DafDev.TemperatureCaptor.Domain.Sensor;
public interface ICaptureTemperatures
{
    double GetTemperature();
    IEnumerable<double> GetTemperatures(int measures = 15);
}
