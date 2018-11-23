using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Adventskalender2018.Interfaces.Infrastructure;

namespace Adventskalender2018.Implementations.Infrastructure
{
    public class DefaultRandomValue : IRandomValue
    {
        public int Next(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue + 1);
        }
    }
}
