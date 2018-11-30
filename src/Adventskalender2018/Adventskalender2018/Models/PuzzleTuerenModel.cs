using System.Collections.Generic;
using System.Linq;

namespace Adventskalender2018.Models
{
    public class PuzzleTuerenModel
    {
        public List<PuzzleTuerModel> Puzzlestuecke { get; set; } = new List<PuzzleTuerModel>();

        public PuzzleTuerModel GebeMirPuzzleStueckAnhandDesTages(int tag)
        {
            return Puzzlestuecke.First(predicate: s => s.Tag == tag);
        }
    }
}
