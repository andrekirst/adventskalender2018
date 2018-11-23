using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Models
{
    public class AdventstuerModel
    {
        public int Tag { get; set; }

        public bool BereitsErfolgreichGeoeffnet { get; set; }

        public override string ToString()
        {
            string geoeffnetText = BereitsErfolgreichGeoeffnet
                ? "geöffnet"
                : "geschlossen";

            return $"Tür {Tag} ist {geoeffnetText}";
        }
    }
}
