using System.Collections.Generic;
using System.Linq;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Models;
using Newtonsoft.Json;
using System;

namespace Adventskalender2018.Implementations.Domain
{
    public class AdventstuerRaetselSpeicher : IAdventstuerRaetselSpeicher
    {
        private readonly IFileSystem _fileSystem;

        public AdventstuerRaetselSpeicher(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public async Task<RaetselModel> LadeRaetsel(int tag)
        {
            string fragenDateiJsonInhalt = _fileSystem.File.ReadAllText("Daten/fragen.json");
            return JsonConvert.DeserializeObject<List<RaetselModel>>(fragenDateiJsonInhalt)
                .First(t => t.Tag == tag);
        }

        public async Task MarkiereRaetselAlsGeloest(int tag)
        {
            List<TuerGeoeffnetModel> geoeffneteTueren = JsonConvert.DeserializeObject<List<TuerGeoeffnetModel>>(
                _fileSystem.File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/Daten/tueren.json"));
            var model = geoeffneteTueren.First(s => s.Tag == tag);
            model.Geoeffnet = true;
            _fileSystem.File.WriteAllText(
                path: $"{AppDomain.CurrentDomain.BaseDirectory}/Daten/tueren.json",
                contents: JsonConvert.SerializeObject(geoeffneteTueren));
        }

        public async Task<bool> IstRichtigeAntwort(string antwortSchluessel, int tag)
        {
            string fragenDateiJsonInhalt = _fileSystem.File.ReadAllText("Daten/fragen.json");
            return JsonConvert.DeserializeObject<List<RaetselModel>>(fragenDateiJsonInhalt)
                .First(t => t.Tag == tag)
                .Antworten.First(s => s.Schluessel == antwortSchluessel)
                .IstKorrekteAntwort;
        }
    }
}