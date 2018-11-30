using Adventskalender2018.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adventskalender2018.Interfaces.Domain
{
    public interface IAlleTuerenSpeicher
    {
        Task<List<AdventstuerModel>> GebeMirAlleAdventstueren();
    }
}
