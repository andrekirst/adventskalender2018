using System.Threading.Tasks;
using Adventskalender2018.Models;

namespace Adventskalender2018.Interfaces.Domain
{
    public interface IAdventstuerRaetselSpeicher
    {
        Task<RaetselModel> LadeRaetsel(int tag);

        Task MarkiereRaetselAlsGeloest(int tag);

        Task<bool> IstRichtigeAntwort(string antwortSchluessel, int tag);
    }
}