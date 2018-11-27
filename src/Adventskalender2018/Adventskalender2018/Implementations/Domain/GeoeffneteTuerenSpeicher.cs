using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;

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
            return HoleAlleTueren().First(s => s.Tag == tag);
        }

        public List<TuerGeoeffnetModel> HoleAlleTueren()
        {
            return JsonConvert.DeserializeObject<List<TuerGeoeffnetModel>>(value: _fileSystem.File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}/Daten/tueren.json"));
        }
    }
}
