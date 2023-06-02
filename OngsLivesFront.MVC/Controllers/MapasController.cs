using Microsoft.AspNetCore.Mvc;
using OngsLivesFront.MVC.API.Interfaces;

namespace OngsLivesFront.MVC.Controllers
{
    public class MapasController : Controller
    {
        private readonly IOngAPI _ongAPI;

        public MapasController(IOngAPI ongAPI)
        {
            _ongAPI= ongAPI;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ongs = await _ongAPI.GetOngs();
            return View(ongs);
        }
    }
}
