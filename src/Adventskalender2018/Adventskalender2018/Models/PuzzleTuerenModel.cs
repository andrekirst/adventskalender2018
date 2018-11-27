using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Models
{
    public class PuzzleTuerenModel
    {
        public List<PuzzleTuerModel> Puzzlestuecke { get; set; } = new List<PuzzleTuerModel>();

        public PuzzleTuerModel GebeMirPuzzleStueckAnhandDesTages(int tag)
        {
            return Puzzlestuecke.First(s => s.Tag == tag);
        }
    }
}
