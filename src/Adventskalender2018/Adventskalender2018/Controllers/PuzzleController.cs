using Adventskalender2018.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Adventskalender2018.Controllers
{
    public class PuzzleController : Controller
    {
        private readonly IPuzzleTuerenSpeicher _puzzleTuerenSpeicher;

        public PuzzleController(IPuzzleTuerenSpeicher puzzleTuerenSpeicher)
        {
            _puzzleTuerenSpeicher = puzzleTuerenSpeicher;
        }

        public IActionResult Index()
        {
            return View(model: _puzzleTuerenSpeicher.HolePuzleTueren());
        }
    }
}