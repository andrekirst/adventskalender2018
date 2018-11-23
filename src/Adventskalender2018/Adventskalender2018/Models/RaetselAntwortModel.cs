using Newtonsoft.Json;

namespace Adventskalender2018.Models
{
    public class RaetselAntwortModel
    {
        [JsonProperty(propertyName: "antworttext")]
        public string Antworttext { get; set; }

        [JsonProperty(propertyName: "schluessel")]
        public string Schluessel { get; set; }

        [JsonProperty(propertyName: "ist_korrekte_antwort")]
        public bool IstKorrekteAntwort { get; set; } = false;

        [JsonProperty(propertyName: "bild")]
        public string Bild { get; set; }
    }
}
