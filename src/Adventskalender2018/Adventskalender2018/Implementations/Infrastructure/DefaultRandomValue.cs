using System;
using Adventskalender2018.Interfaces.Infrastructure;

namespace Adventskalender2018.Implementations.Infrastructure
{
    public class DefaultRandomValue : IRandomValue
    {
        public int Next(int minValue, int maxValue)
        {
            return new Random().Next(
                minValue: minValue,
                maxValue: maxValue + 1);
        }
    }
}
