using System.IO.Abstractions;
using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Interfaces.Infrastructure;
using Adventskalender2018.Models;

namespace Adventskalender2018.Implementations.Domain
{
    public class AdventstuerSpeicher : IAdventstuerSpeicher
    {
        private readonly IFileSystem _fileSystem;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AdventstuerSpeicher(
            IFileSystem fileSystem,
            IDateTimeProvider dateTimeProvider)
        {
            _fileSystem = fileSystem;
            _dateTimeProvider = dateTimeProvider;
        }

        public AdventstuerModel HoleAdventstuerInformation(int tag)
        {
            return new AdventstuerModel
            {
                Tag = tag,
                BereitsErfolgreichGeoeffnet = false
            };
        }
    }
}