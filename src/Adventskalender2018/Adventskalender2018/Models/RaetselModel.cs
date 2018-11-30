using System.Collections.Generic;
using Newtonsoft.Json;

namespace Adventskalender2018.Models
{
    public class RaetselModel
    {
        [JsonProperty(propertyName: "tag")]
        public int Tag { get; set; }

        [JsonProperty(propertyName: "frage")]
        public string Frage { get; set; }

        [JsonProperty(propertyName: "antworten")]
        public List<RaetselAntwortModel> Antworten { get; set; }

        [JsonProperty(propertyName: "frage_Korrekt_beantwortet_text")]
        public string FrageKorrektBeantwortetText { get; set; }

        [JsonProperty(propertyName: "frage_falsch_beantwortet_text")]
        public string FrageFalschBeantwortetText { get; set; }
    }
}
