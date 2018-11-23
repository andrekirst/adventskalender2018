using System.Collections.Generic;
using System.Linq;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Models;
using Newtonsoft.Json;

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
            string fragenDateiJsonInhalt = _fileSystem.File.ReadAllText("fragen.json");
            return JsonConvert.DeserializeObject<List<RaetselModel>>(fragenDateiJsonInhalt)
                .First(t => t.Tag == tag);
        }

        public async Task MarkiereRaetselAlsGeloest(int tag)
        {
        }

        public async Task<bool> IstRichtigeAntwort(string antwortSchluessel, int tag)
        {
            string fragenDateiJsonInhalt = _fileSystem.File.ReadAllText("fragen.json");
            return JsonConvert.DeserializeObject<List<RaetselModel>>(fragenDateiJsonInhalt)
                .First(t => t.Tag == tag)
                .Antworten.First(s => s.Schluessel == antwortSchluessel)
                .IstKorrekteAntwort;
        }
    }
}