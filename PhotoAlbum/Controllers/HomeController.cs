using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PhotoAlbum.Models;
using PhotoAlbum.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientAPI clientAPI;

        public HomeController(ILogger<HomeController> logger, IClientAPI client)
        {
            _logger = logger;
            clientAPI = client;
        }

        public async Task<IActionResult> Index()
        {
            return View((await clientAPI.GetAlbums()).ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Photos(int id)
        {
            return View((await clientAPI.GetPhotos(id)).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> GetPartial(int id)
        {
            
            return PartialView("_ComentsPartial", (await clientAPI.GetCommnets(id)).ToList());
        }

        [HttpGet("json/{cedula}")]
        public async Task<IActionResult> GetJson(int cedula)
        {
            var fileContent = System.IO.File.ReadAllText(@"./Data/extraba.json");


            var json = JsonConvert.DeserializeObject<ExtrabaList>(fileContent);

            var resultado = json.Extraba.Where(e => e.Cedula == cedula).SingleOrDefault();

            return Ok(resultado);
        }
    }
}
