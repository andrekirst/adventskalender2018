using System;
using Adventskalender2018.Interfaces.Infrastructure;

namespace Adventskalender2018.Implementations.Infrastructure
{
    public class DefaultDateTimeProvider : IDateTimeProvider
    {
        public DateTime Today => DateTime.Today;
    }
}