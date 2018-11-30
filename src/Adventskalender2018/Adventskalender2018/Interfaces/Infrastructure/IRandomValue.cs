namespace Adventskalender2018.Interfaces.Infrastructure
{
    public interface IRandomValue
    {
        int Next(int minValue, int maxValue);
    }
}
