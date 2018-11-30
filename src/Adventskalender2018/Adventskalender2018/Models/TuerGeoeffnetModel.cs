using Newtonsoft.Json;

namespace Adventskalender2018.Models
{
    public class TuerGeoeffnetModel
    {
        [JsonProperty(PropertyName = "tag")]
        public int Tag { get; set; }

        [JsonProperty(PropertyName = "geoeffnet")]
        public bool Geoeffnet { get; set; }
    }
}
