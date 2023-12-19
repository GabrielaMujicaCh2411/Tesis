using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Configuracion;
using Copreter.Models.Cita;
using Copreter.Models.Configuracion;
using Copreter.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    [Authorize]
    public class ConfiguracionController : BaseController
    {
        #region Fields

        private readonly ILogger<ConfiguracionController> _logger;

        private readonly IConfiguracionService _service;

        #endregion

        public ConfiguracionController(IMapper mapper, ILogger<ConfiguracionController> logger,
            IConfiguracionService service) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var resultService = await this._service.ListarAsync();

            var result = new ConfiguracionIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ConfiguracionDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? page)
        {
            var resultService = await this._service.ListarAsync();

            var result = new ConfiguracionIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ConfiguracionDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var result = await this._service.ObtenerAsync(id.Value);

            var res = this.Mapper.Map<ConfiguracionEditableVM>(result);
            return View(res);
        }

        public IActionResult Crear()
        {
            return View(new ConfiguracionEditableVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] ConfiguracionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(this.Mapper.Map<ConfiguracionEditableVM>(dto));
            }

            dto.IdUsuarioRegistro = this.UserId();

            var result = await this._service.AgregarAsync(this.Mapper.Map<TConfiguracion>(dto));
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra, new { userId = this.UserId() });
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id);

            var result = this.Mapper.Map<ConfiguracionEditableVM>(resultService);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] ConfiguracionDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    dto.IdUsuarioModificacion = this.UserId();

                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TConfiguracion>(dto));
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


    }
}
