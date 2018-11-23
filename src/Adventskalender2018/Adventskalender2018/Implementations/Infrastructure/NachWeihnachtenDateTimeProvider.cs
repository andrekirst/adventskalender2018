using System;
using Adventskalender2018.Interfaces.Infrastructure;

namespace Adventskalender2018.Implementations.Infrastructure
{
    public class NachWeihnachtenDateTimeProvider : IDateTimeProvider
    {
        public DateTime Today => new DateTime(year: 2018, month: 12, day: 25);
    }
}