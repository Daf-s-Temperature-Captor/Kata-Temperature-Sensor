namespace DafDev.TemperatureCaptor.Infrastructure.InMemoryDataAccess;
public class Context
{
    public List<double> Temperatures { get; set; }

    public Context() => Temperatures = new List<double>();
}
