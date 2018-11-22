using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Models
{
    public class RaetselAntwortModel
    {
        public string Antworttext { get; set; }

        public bool IstKorrekteAntwort { get; set; } = false;
    }
}
