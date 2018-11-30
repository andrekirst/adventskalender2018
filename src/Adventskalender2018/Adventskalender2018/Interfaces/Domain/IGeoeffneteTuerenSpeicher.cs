using Adventskalender2018.Models;
using System.Collections.Generic;

namespace Adventskalender2018.Interfaces.Domain
{
    public interface IGeoeffneteTuerenSpeicher
    {
        TuerGeoeffnetModel HoleTuerFuerTag(int tag);

        List<TuerGeoeffnetModel> HoleAlleTueren();
    }
}
