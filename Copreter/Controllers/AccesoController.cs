using Microsoft.AspNetCore.Mvc;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Model.DbModel;
using AutoMapper;
using Copreter.Domain.Service.Dto;
using Copreter.Utils;
using Copreter.Models.Acceso;
using Copreter.Domain.Service.Dto.Acceso;
using Copreter.Domain.Service.Dto.Usuario;
using static Copreter.Utils.Keys;

namespace Copreter.Controllers
{
    public class AccesoController : BaseController
    {
        #region Fields

        private readonly ILogger<AccesoController> _logger;

        private readonly IAccesoService _service;

        private readonly IRolService _rolService;

        private readonly IUsuarioService _usuarioService;

        #endregion

        public AccesoController(IMapper mapper, ILogger<AccesoController> logger,
            IAccesoService service, IRolService rolService, IUsuarioService usuarioService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._rolService = rolService;
            this._usuarioService = usuarioService;
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

        public async Task<IActionResult> Crear()
        {
            var rolLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._rolService.ListarAsync());
            var result = new AccesoEditableVM
            {
                RolLista = rolLista.GetItems()
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] AccesoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var result = await this._usuarioService.AgregarAsync(this.Mapper.Map<TUsuario>(dto));
                if (result != null)
                {
                    await this._service.AgregarAsync(result.Id, this.Mapper.Map<TAcceso>(dto));

                    return RedirectToAction(ActionKeys.Index, ControllerKeys.Home);
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
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
                    var resultUser = await this._usuarioService.ActualizarAsync(id, this.Mapper.Map<TUsuario>(dto));
                    if (resultUser)
                    {
                        var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TAcceso>(dto));
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