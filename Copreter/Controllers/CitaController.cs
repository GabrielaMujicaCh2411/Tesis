using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Model.Cita;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Cita;
using Copreter.Models.Cita;
using Copreter.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    [Authorize]
    public class CitaController : BaseController
    {

        #region Fields

        private readonly ILogger<CitaController> _logger;

        private readonly ICitaService _service;

        private readonly IObraService _obraService;

        private readonly IUsuarioService _usuarioService;

        #endregion


        public CitaController(IMapper mapper, ILogger<CitaController> logger,
            ICitaService service, IObraService obraService, IUsuarioService usuarioService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._obraService = obraService;
            this._usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index(int? idEstado = 0)
        {
            var resultService = await this._service.ListarAsync(new CitaFilter() { IdEstado = idEstado });

            var result = new CitaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<CitaDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? idEstado = 0)
        {
            var resultService = await this._service.ListarAsync(new CitaFilter() { IdEstado = idEstado });

            var result = new CitaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<CitaDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);

            var usuario = await this._usuarioService.ObtenerAsync(result.IdUsuarioRegistro);

            var res = this.Mapper.Map<CitaEditableVM>(result);
            res.Usuario = $"{usuario.Nombre} {usuario.Apellido}";
            res.EstadoObra = "Citado";
            return View(res);
        }

        public async Task<IActionResult> Crear(int? idObra)
        {
            var obra = await this._obraService.ObtenerAsync(idObra.Value);

            if (obra == null) return RedirectToAction(Keys.ActionKeys.Index);
  
            return View(new CitaEditableVM() { IdObra = idObra, NombreObra = obra.NombreObra, Fecha = DateTime.Now  });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] CitaDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(this.Mapper.Map<CitaEditableVM>(dto));
            }

            dto.IdUsuarioRegistro = this.UserId();

            var result = await this._service.AgregarAsync(this.Mapper.Map<TCita>(dto));
            if (result)
            {
                await this._obraService.ActualizarEstadoAsync(dto.IdObra.Value, (int)Domain.Model.Enums.EObraEstado.Citado, this.UserId());
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra, new { userId = this.UserId() });
        }

    }
}