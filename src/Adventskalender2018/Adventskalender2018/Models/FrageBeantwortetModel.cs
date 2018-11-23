using static System.String;

namespace Adventskalender2018.Models
{
    public class FrageBeantwortetModel
    {
        public int Tag { get; set; }

        public bool IstFrageRichtigBeantwortet { get; set; } = false;

        public string FrageKorrektBeantwortetText { get; set; }

        public string FrageFalschBeantwortetText { get; set; }

        public string Adventsschluessel { get; set; }

        public string Bild { get; set; }

        public bool HatBild => !IsNullOrEmpty(value: Bild);
    }
}