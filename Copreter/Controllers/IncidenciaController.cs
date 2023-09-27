using AutoMapper;
using Copreter.Domain.Service.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Copreter.Domain.Model.Model.Incidencia;
using Copreter.Domain.Service.Dto.Incidencia;
using Copreter.Models.Incidencia;
using Copreter.Domain.Model.DbModel;
using Copreter.Utils;
using Copreter.Domain.Service.Dto.Trabajador;
using Copreter.Domain.Service.Dto;
using static Copreter.Utils.Keys;
using Copreter.Models.Trabajador;

namespace Copreter.Controllers
{
    [Authorize]
    public class IncidenciaController : BaseController
    {
        #region Fields

        private readonly ILogger<IncidenciaController> _logger;

        private readonly IIncidenciaService _service;

        private readonly IPedidoService _pedidoService;

        #endregion

        public IncidenciaController(IMapper mapper, ILogger<IncidenciaController> logger, IIncidenciaService service, IPedidoService pedidoService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._pedidoService = pedidoService;
        }

        public async Task<IActionResult> Index(int? idPedido = 0)
        {

            var resultService = await this._service.ListarAsync(new IncidenciaFilter() { IdPedido =idPedido});

            var result = new IncidenciaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<IncidenciaDto>>(resultService),
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? idPedido = 0)
        {
            var resultService = await this._service.ListarAsync(new IncidenciaFilter() { IdPedido = idPedido });

            var result = new IncidenciaIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<IncidenciaDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Crear(int idPedido)
        {
            var pedido = await this._pedidoService.ObtenerAsync(idPedido);

            var result = new IncidenciaEditableVM
            {
                IdPedido = idPedido,
                Pedido = pedido.Obra,
                Fecha = DateTime.Now,
            };
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] IncidenciaDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var modelInvalid = this.Mapper.Map<IncidenciaEditableVM>(dto);

                    return View(modelInvalid);
                }

                dto.IdUsuarioRegistro = this.UserId();
                var result = await this._service.AgregarAsync(this.Mapper.Map<TIncidencia>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index), Keys.ControllerKeys.Pedido);
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

            var result = this.Mapper.Map<IncidenciaEditableVM>(resultService);

            return View(result);
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0) return RedirectToAction(nameof(Index));

            var resultService = await this._service.ObtenerAsync(id);

            var result = this.Mapper.Map<IncidenciaEditableVM>(resultService);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind()] IncidenciaDto dto)
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
                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TIncidencia>(dto));
                    if (result)
                    {
                        return RedirectToAction(nameof(Index), Keys.ControllerKeys.Pedido);
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

            return PartialView(PartialViewKeys.Delete, this.Mapper.Map<IncidenciaDto>(result));
        }

        // POST: Incidencia/Delete/5
        [HttpPost, ActionName("DeletePopupConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePopupConfirmed([Bind()] IncidenciaDto dto)
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
