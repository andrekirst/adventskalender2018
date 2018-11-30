using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;

namespace Adventskalender2018.Implementations.Domain
{
    public class GeoeffneteTuerenSpeicher : IGeoeffneteTuerenSpeicher
    {
        private readonly IFileSystem _fileSystem;

        public GeoeffneteTuerenSpeicher(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public TuerGeoeffnetModel HoleTuerFuerTag(int tag)
        {
            return HoleAlleTueren()
                .First(predicate: s => s.Tag == tag);
        }

        public List<TuerGeoeffnetModel> HoleAlleTueren()
        {
            string fileContent = _fileSystem.File.ReadAllText(path: $"{AppDomain.CurrentDomain.BaseDirectory}/Daten/tueren.json");
            return JsonConvert.DeserializeObject<List<TuerGeoeffnetModel>>(value: fileContent);
        }
    }
}
