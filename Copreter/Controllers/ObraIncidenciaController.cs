using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Utils;
using Microsoft.AspNetCore.Mvc;
using static Copreter.Utils.Keys;
using Copreter.Domain.Model.Model.Obra;
using Copreter.Domain.Service.Dto.ObraIncidencia;
using Copreter.Models.ObraIncidencia;

namespace Copreter.Controllers
{
    public class ObraIncidenciaController : BaseController
    {
        #region Fields

        private readonly ILogger<ObraIncidenciaController> _logger;

        private readonly IObraIncidenciaService _service;

        private readonly IObraService _obraService;

        #endregion

        public ObraIncidenciaController(IMapper mapper, ILogger<ObraIncidenciaController> logger, IObraIncidenciaService service, IObraService obraService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._obraService = obraService;
        }

        public async Task<IActionResult> Index(int? idObra = 0)
        {

            var resultService = await this._service.ListarAsync(new ObraIndicendiaFilter() { IdObra = idObra });

            var result = new ObraIncidenciaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ObraIncidenciaDto>>(resultService),
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? idObra = 0)
        {
            var resultService = await this._service.ListarAsync(new ObraIndicendiaFilter() { IdObra = idObra });

            var result = new ObraIncidenciaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<ObraIncidenciaDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Crear(int idObra)
        {
            var obra = await this._obraService.ObtenerAsync(idObra);

            var result = new ObraIncidenciaEditableVM
            {
                IdObra = idObra,
                Obra = obra.NombreObra,
                Fecha = DateTime.Now,
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] ObraIncidenciaDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var modelInvalid = this.Mapper.Map<ObraIncidenciaEditableVM>(dto);

                    return View(modelInvalid);
                }

                dto.IdUsuarioRegistro = this.UserId();
                var result = await this._service.AgregarAsync(this.Mapper.Map<TObraIncidencia>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Detalle(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id);

            var result = this.Mapper.Map<ObraIncidenciaEditableVM>(resultService);

            return View(result);
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id);

            var result = this.Mapper.Map<ObraIncidenciaEditableVM>(resultService);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] ObraIncidenciaDto dto)
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
                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TObraIncidencia>(dto));
                    if (result)
                    {
                        return RedirectToAction(nameof(Index), Keys.ControllerKeys.Obra);
                    }
                }

                return RedirectToAction(nameof(Editar), id);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View(dto.Id);
            }
        }

        // GET: Incidencia/Delete/5
        [HttpPost, ActionName("DeletePopup")]
        public async Task<IActionResult> DeletePopup([FromBody] EditDto dto)
        {
            if (dto == null || dto.Id == 0)
            {
                return NotFound();
            }

            var result = await this._service.ObtenerAsync(dto.Id);
            if (result == null)
            {
                return NotFound();
            }

            return PartialView(PartialViewKeys.Delete, this.Mapper.Map<ObraIncidenciaDto>(result));
        }

        // POST: Incidencia/Delete/5
        [HttpPost, ActionName("DeletePopupConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePopupConfirmed([Bind()] ObraIncidenciaDto dto)
        {
            if (dto == null)
            {
                return NotFound();
            }

            var result = await this._service.ObtenerAsync(dto.Id);
            if (result != null)
            {
                await this._service.EliminarAsync(dto.Id, this.UserId());
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
