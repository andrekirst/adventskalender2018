using Adventskalender2018.Models;

namespace Adventskalender2018.Interfaces.Domain
{
    public interface IAdventstuerSpeicher
    {
        AdventstuerModel HoleAdventstuerInformation(int tag);
    }
}