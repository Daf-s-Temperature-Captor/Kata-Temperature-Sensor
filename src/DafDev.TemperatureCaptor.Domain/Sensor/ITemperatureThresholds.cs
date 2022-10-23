namespace DafDev.TemperatureCaptor.Domain.Sensor;
public interface ITemperatureThresholds
{
    double FromColdToWarm { get; set; }
    double FromWarmToHot { get; set; }

    void ModifiyFromColdToWarmThreshold(double newTemperature);
    void ModifiyFromWarmToHotThreshold(double newTemperature);
}
