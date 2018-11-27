using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Models
{
    public class TuerModel
    {
        public int Tag { get; set; }

        public string Frage { get; set; }

        public bool DarfDieFrageBeantwortetWerden { get; set; }

        public List<RaetselAntwortModel> Antworten { get; set; } = new List<RaetselAntwortModel>();

        public bool BereitsErfolgreichGeoeffnet { get; set; } = false;

        public string SchluesselWennErfolgreichBeantwortet { get; set; }
    }
}
