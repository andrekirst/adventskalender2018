using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Models
{
    public class RaetselModel
    {
        public int Tag { get; set; }

        public string Frage { get; set; }

        public List<RaetselAntwortModel> Antworten { get; set; }
    }
}
