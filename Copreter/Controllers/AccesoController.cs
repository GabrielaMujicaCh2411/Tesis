using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;
using AutoMapper;
using Copreter.Domain.Service.Dto;
using Copreter.Utils;
using Copreter.Models.Acceso;
using Copreter.Domain.Service.Dto.Acceso;

namespace Copreter.Controllers
{
    public class AccesoController : BaseController
    {
        #region Fields

        private readonly IAccesoService _service;

        private readonly IRolService _rolService;

        #endregion

        public AccesoController(IMapper mapper, IAccesoService service, IRolService rolService) : base(mapper)
        {
            this._service = service;
            this._rolService = rolService;
        }

        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new AccesoIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<AccesoDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new AccesoIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<AccesoDto>>(resultService)
            };
            return PartialView(result);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] TAcceso dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var usuarioExiste = await this._service.ObtenerAsync(dto.Id);
            if (usuarioExiste == null)
            {
                var result = await this._service.AgregarAsync(dto);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(dto);
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id);

            var rolLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._rolService.ListarAsync());

            var result = this.Mapper.Map<AccesoEditableVM>(resultService);
            result.RolLista = rolLista.GetItems();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] AccesoDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TAcceso>(dto));
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(dto);
            }
            catch
            {
                return View(dto);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}