using K.UI.AppWebMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ProyectoCrudK.AppWebMvc.Models;
using ProyectoCrudK.BLL.Service;
using ProyectoCrudK.Models;
using System.Diagnostics;
using System.Globalization;

namespace ProyectoCrudK.AppWebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactoService _contactoService;

        public HomeController(IContactoService contactoServ)
        {
            _contactoService = contactoServ;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<PersonaK> queryPersonaKSQL = await _contactoService.ObtenerTodos();

            List<VMContacto> lista = queryPersonaKSQL
                .Select(k=> new VMContacto()
                {
                    Id = k.Id,
                    NombreK = k.NombreK,
                    ApellidoK = k.ApellidoK,
                    FechaNacimientoK = k.FechaNacimientoK.Value.ToString("dd/mm/yyyy"),
                    SueldoK = k.SueldoK,
                    EstatusK = k.EstatusK
                }).ToList();
            return StatusCode(StatusCodes.Status200OK,lista);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMContacto modelo)
        {
            PersonaK NuevoModelo = new PersonaK()
            {
                NombreK=modelo.NombreK,
                ApellidoK = modelo.ApellidoK,
                FechaNacimientoK = DateTime.ParseExact(modelo.FechaNacimientoK,"dd/mm/yyyy",CultureInfo.CreateSpecificCulture("es-SV")),
                SueldoK=modelo.SueldoK,
                EstatusK=modelo.EstatusK


            };
            bool respuesta = await _contactoService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new {valor = respuesta});
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMContacto modelo)
        {
            PersonaK NuevoModelo = new PersonaK()
            {
                Id=modelo.Id,
                NombreK = modelo.NombreK,
                ApellidoK = modelo.ApellidoK,
                FechaNacimientoK = DateTime.ParseExact(modelo.FechaNacimientoK, "dd/mm/yyyy", CultureInfo.CreateSpecificCulture("es-SV")),
                SueldoK = modelo.SueldoK,
                EstatusK = modelo.EstatusK


            };
            bool respuesta = await _contactoService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            bool respuesta = await _contactoService.Eliminar(id); 

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
