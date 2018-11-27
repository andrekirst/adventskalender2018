using System;
using System.Linq;
using System.Threading.Tasks;
using Adventskalender2018.Interfaces.Domain;
using Adventskalender2018.Interfaces.Infrastructure;
using Adventskalender2018.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adventskalender2018.Controllers
{
    public class TuerchenController : Controller
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IAdventstuerSpeicher _adventstuerSpeicher;
        private readonly IAdventstuerRaetselSpeicher _adventstuerRaetselSpeicher;
        private readonly IGeoeffneteTuerenSpeicher _geoeffneteTuerenSpeicher;

        public TuerchenController(
            IDateTimeProvider dateTimeProvider,
            IAdventstuerSpeicher adventstuerSpeicher,
            IAdventstuerRaetselSpeicher adventstuerRaetselSpeicher,
            IGeoeffneteTuerenSpeicher geoeffneteTuerenSpeicher)
        {
            _dateTimeProvider = dateTimeProvider;
            _adventstuerSpeicher = adventstuerSpeicher;
            _adventstuerRaetselSpeicher = adventstuerRaetselSpeicher;
            _geoeffneteTuerenSpeicher = geoeffneteTuerenSpeicher;
        }

        public async Task<IActionResult> Tuer(int tag)
        {
            RaetselModel raetsel = await _adventstuerRaetselSpeicher.LadeRaetsel(tag);

            TuerGeoeffnetModel tuer = _geoeffneteTuerenSpeicher.HoleTuerFuerTag(tag: tag);
            
            return View(model: new TuerModel
            {
                Tag = tag,
                DarfDieFrageBeantwortetWerden = _dateTimeProvider.Today >= new DateTime(2018, 12, tag),
                Frage = raetsel.Frage,
                Antworten = raetsel.Antworten,
                BereitsErfolgreichGeoeffnet = tuer.Geoeffnet,
                SchluesselWennErfolgreichBeantwortet = tuer.Geoeffnet ? raetsel.Antworten.First(s => s.IstKorrekteAntwort).Schluessel : null
            });
        }

        public async Task<IActionResult> Beantworten(int tag, string schluessel)
        {
            bool istFrageRichtigBeantortet = await _adventstuerRaetselSpeicher
                .IstRichtigeAntwort(antwortSchluessel: schluessel, tag: tag);

            if (istFrageRichtigBeantortet)
            {
                await _adventstuerRaetselSpeicher.MarkiereRaetselAlsGeloest(tag); 
            }

            RaetselModel raetsel = await _adventstuerRaetselSpeicher.LadeRaetsel(tag);

            return View(model: new FrageBeantwortetModel
            {
                Tag = tag,
                IstFrageRichtigBeantwortet = istFrageRichtigBeantortet,
                Adventsschluessel = istFrageRichtigBeantortet ? schluessel : null,
                FrageFalschBeantwortetText = istFrageRichtigBeantortet ? null : raetsel.FrageFalschBeantwortetText,
                FrageKorrektBeantwortetText = istFrageRichtigBeantortet ? raetsel.FrageKorrektBeantwortetText : null,
                Bild = raetsel.Antworten.First(s => s.Schluessel == schluessel).Bild
            });
        }
    }
}