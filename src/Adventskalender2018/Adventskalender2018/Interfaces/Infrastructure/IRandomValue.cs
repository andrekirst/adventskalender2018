using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Interfaces.Infrastructure
{
    public interface IRandomValue
    {
        int Next(int minValue, int maxValue);
    }
}
