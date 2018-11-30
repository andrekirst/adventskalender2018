using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;

namespace Adventskalender2018.Implementations.Domain
{
    public class PuzzleTuerenSpeicher : IPuzzleTuerenSpeicher
    {
        private readonly IFileSystem _fileSystem;
        private readonly IGeoeffneteTuerenSpeicher _geoeffneteTuerenSpeicher;

        public PuzzleTuerenSpeicher(
            IFileSystem fileSystem,
            IGeoeffneteTuerenSpeicher geoeffneteTuerenSpeicher)
        {
            _fileSystem = fileSystem;
            _geoeffneteTuerenSpeicher = geoeffneteTuerenSpeicher;
        }

        public PuzzleTuerenModel HolePuzleTueren()
        {
            List<PuzzleBildModel> puzzleBilder = JsonConvert.DeserializeObject<List<PuzzleBildModel>>(value: _fileSystem.File.ReadAllText(path: $"{AppDomain.CurrentDomain.BaseDirectory}/Daten/puzzletag.json"));
            List<TuerGeoeffnetModel> geoeffneteTueren = _geoeffneteTuerenSpeicher.HoleAlleTueren();

            IEnumerable<PuzzleTuerModel> result =
                from tuer in geoeffneteTueren
                join bild in puzzleBilder on
                    tuer.Tag equals bild.Tag
                select new PuzzleTuerModel
                {
                    Bild = tuer.Geoeffnet ? bild.Bild : null,
                    IstGeoffnet = tuer.Geoeffnet,
                    Tag = tuer.Tag
                };
            PuzzleTuerenModel puzzleTuerenModel = new PuzzleTuerenModel();
            puzzleTuerenModel.Puzzlestuecke.AddRange(collection: result);
            return puzzleTuerenModel;
        }
    }
}
