using Newtonsoft.Json;

namespace Adventskalender2018.Models
{
    public class PuzzleBildModel
    {
        [JsonProperty(PropertyName = "tag")]
        public int Tag { get; set; }

        [JsonProperty(PropertyName = "bild")]
        public string Bild { get; set; }
    }
}
