using DafDev.TemperatureCaptor.Domain.Sensor;

namespace DafDev.TemperatureCaptor.Infrastructure.InMemoryDataAccess;
public class TemperatureRepository : ICaptureTemperatures
{
    private readonly Random _random;
    private readonly Context _context;

    public TemperatureRepository(Context context)
    {
        _context = context;
        _random = new Random();
    }

    public async Task<double> GetTemperature()
    {
        //We generate a random temperature between -40 and 60 °C
        var temperature = _random.NextDouble()*100 - 40;
        _context.Temperatures.Add(temperature);
        return await Task.FromResult(temperature);
    }

    public async Task<IEnumerable<double>> GetTemperatures(int numberOfMeasures = 15)
    {
        if(numberOfMeasures > _context.Temperatures.Count)
            numberOfMeasures = _context.Temperatures.Count;

        return await Task.FromResult(_context.Temperatures.TakeLast(numberOfMeasures));
    }
}
