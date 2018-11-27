using Adventskalender2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Interfaces.Domain
{
    public interface IGeoeffneteTuerenSpeicher
    {
        TuerGeoeffnetModel HoleTuerFuerTag(int tag);

        List<TuerGeoeffnetModel> HoleAlleTueren();
    }
}
