using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Interfaces.Infrastructure;
using Adventskalender2018.Models;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Adventskalender2018.Implementations.Domain
{
    public class AlleTuerenSpeicher : IAlleTuerenSpeicher
    {
        private readonly IFileSystem _fileSystem;
        private readonly IRandomValue _randomValue;

        public AlleTuerenSpeicher(
            IFileSystem fileSystem,
            IRandomValue randomValue)
        {
            _fileSystem = fileSystem;
            _randomValue = randomValue;
        }

        public async Task<List<AdventstuerModel>> GebeMirAlleAdventstueren()
        {
            List<int> tueren = new List<int>(24);
            tueren.AddRange(Enumerable.Range(1, 24));

            List<AdventstuerModel> zufaelligeListe = new List<AdventstuerModel>(24);

            for (int i = 0; i < 24; i++)
            {
                int tuer = tueren[_randomValue.Next(0, 24)];
                await Task.Delay(millisecondsDelay: 25);
                zufaelligeListe.Add(new AdventstuerModel
                {
                    Tag = tuer
                });
            }

            return zufaelligeListe;
        }
    }
}
