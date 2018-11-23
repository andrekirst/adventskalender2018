using System;

namespace Adventskalender2018.Interfaces.Infrastructure
{
    public interface IDateTimeProvider
    {
        DateTime Today { get; }
    }
}