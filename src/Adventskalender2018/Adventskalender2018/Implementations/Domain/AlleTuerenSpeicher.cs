using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Interfaces.Infrastructure;
using Adventskalender2018.Models;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Adventskalender2018.Implementations.Domain
{
    public class AlleTuerenSpeicher : IAlleTuerenSpeicher
    {
        private readonly IFileSystem _fileSystem;
        private readonly IRandomValue _randomValue;
        private readonly IGeoeffneteTuerenSpeicher _geoeffneteTuerenSpeicher;

        public AlleTuerenSpeicher(
            IFileSystem fileSystem,
            IRandomValue randomValue,
            IGeoeffneteTuerenSpeicher geoeffneteTuerenSpeicher)
        {
            _fileSystem = fileSystem;
            _randomValue = randomValue;
            _geoeffneteTuerenSpeicher = geoeffneteTuerenSpeicher;
        }

        public async Task<List<AdventstuerModel>> GebeMirAlleAdventstueren()
        {
            List<int> tueren = new List<int>(capacity: 24);
            tueren.AddRange(collection: Enumerable.Range(start: 1, count: 24));

            List<AdventstuerModel> zufaelligeListe = new List<AdventstuerModel>(capacity: 24);
            List<TuerGeoeffnetModel> geoeffneteTueren = _geoeffneteTuerenSpeicher.HoleAlleTueren();

            for (int i = 23; i >= 0; i--)
            {
                int tuer = tueren[index: _randomValue.Next(minValue: 0, maxValue: i)];
                await Task.Delay(millisecondsDelay: 13);
                zufaelligeListe.Add(item: new AdventstuerModel
                {
                    Tag = tuer,
                    BereitsErfolgreichGeoeffnet = geoeffneteTueren.First(s => s.Tag == tuer).Geoeffnet
                });
                tueren.Remove(tuer);
            }

            return zufaelligeListe;
        }
    }
}
