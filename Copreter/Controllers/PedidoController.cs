using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Pedido;
using Copreter.Models.Pedido;
using Copreter.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    [Authorize]
    public class PedidoController : BaseController
    {
        #region Fields

        private readonly ILogger<PedidoController> _logger;

        private readonly IPedidoService _service;

        private readonly ITrabajadorService _trabajadorService;

        private readonly IEstadoPedidoService _estadoPedidoService;

        private readonly IUnidadService _unidadService;

        #endregion

        public PedidoController(IMapper mapper, ILogger<PedidoController> logger, IPedidoService service,
            ITrabajadorService trabajadorService, IEstadoPedidoService estadoPedidoService, IUnidadService unidadService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._trabajadorService = trabajadorService;
            this._estadoPedidoService = estadoPedidoService;
            this._unidadService = unidadService;
        }

        public async Task<IActionResult> Index(int? userId, int? idEstado)
        {
            var resultService = await this._service.ListarAsync(new Domain.Model.Model.Pedido.PedidoFilter() { IdUsuario = userId, IdEstado = idEstado });

            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoPedidoService.ListarAsync());

            var result = new PedidoIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PedidoDto>>(resultService),
                Filtro = new PedidoFilterDto(),
                EstadoLista = estadoLista.GetItems(),
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int? userId, int? idEstado)
        {
            var resultService = await this._service.ListarAsync(new Domain.Model.Model.Pedido.PedidoFilter() { IdUsuario = userId, IdEstado = idEstado });

            var estadoLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._estadoPedidoService.ListarAsync());

            var result = new PedidoIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PedidoDto>>(resultService),
                Filtro = new PedidoFilterDto(),
                EstadoLista = estadoLista.GetItems(),
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Asignar(int id)
        {
            var resultService = await this._service.ObtenerAsync(id);
            if (resultService == null) return RedirectToAction(nameof(Index));

            var trabajadorLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._trabajadorService.ListarAsync(new Domain.Model.Model.Trabajador.TrabajadorFilter()));

            var result = this.Mapper.Map<PedidoEditableVM>(resultService);
            result.TrabajadorLista = trabajadorLista.GetItems();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Asignar(int id, [Bind()] PedidoDto dto)
        {
            try
            {
                if (id != dto.Id)
                {
                    return NotFound();
                }

                if (dto.IdTrabajador == null || dto.IdTrabajador == 0)
                {
                    var trabajadorLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._trabajadorService.ListarAsync(new Domain.Model.Model.Trabajador.TrabajadorFilter()));

                    var resultInvalid = this.Mapper.Map<PedidoEditableVM>(dto);
                    resultInvalid.TrabajadorLista = trabajadorLista.GetItems();

                    return View(resultInvalid);
                }

                dto.IdEstadoPedido = 3;
                dto.IdUsuarioModificacion = this.UserId();

                var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TPedido>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }


        public async Task<IActionResult> Aceptar(int id)
        {
            var resultService = await this._service.ObtenerAsync(id);
            if (resultService == null) return RedirectToAction(nameof(Index));

            resultService.IdEstadoPedido = (int)EPedidoEstado.Aceptado;
            resultService.IdUsuarioModificacion = this.UserId();

            var result = await this._service.ActualizarAsync(id, resultService);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }

        public async Task<IActionResult> Rechazar(int id)
        {
            var resultService = await this._service.ObtenerAsync(id);
            if (resultService == null) return RedirectToAction(nameof(Index));

            resultService.IdEstadoPedido = (int)EPedidoEstado.Rechazado;
            resultService.IdUsuarioModificacion = this.UserId();

            var result = await this._service.ActualizarAsync(id, resultService);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }

        public async Task<IActionResult> Alquilar(int idUnidad)
        {
            var resultService = await this._unidadService.ObtenerAsync(idUnidad);
            if (resultService == null) return RedirectToAction(nameof(Index));

            var result = new PedidoEditableVM
            {
                FechaInicio = DateTime.Now,
                PrecioUnidad = resultService.Precio,
                IdUnidad = idUnidad,
                Cantidad = 1,
                CantidadDias = 1,
                PrecioPedido = 1 * resultService.Precio,
            };

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alquilar([Bind()] PedidoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var resultInvalid = this.Mapper.Map<PedidoEditableVM>(dto);
                    return View(resultInvalid);
                }

                if (dto.FechaInicio <= DateTime.Now)
                {
                    ViewData["ValidateMessage"] = "La fecha de inicio debe ser mayor a la fecha de hoy";

                    var resultInvalid = this.Mapper.Map<PedidoEditableVM>(dto);
                    return View(resultInvalid);
                }

                if (dto.FechaInicio >= DateTime.Now.AddDays(8))
                {
                    ViewData["ValidateMessage"] = "La fecha de inicio no debe ser mayor a la 7 días";

                    var resultInvalid = this.Mapper.Map<PedidoEditableVM>(dto);
                    return View(resultInvalid);
                }


                var resultServiceUnidad = await this._unidadService.ObtenerAsync(dto.IdUnidad);
                if (resultServiceUnidad != null)
                {
                    if (resultServiceUnidad.CantidadDisponible < dto.Cantidad)
                    {
                        ViewData["ValidateMessage"] = "Cantidad insuficientes de unidades";
                        var resultInvalid = this.Mapper.Map<PedidoEditableVM>(dto);
                        return View(resultInvalid);
                    }

                    dto.IdUsuario = this.UserId();
                    dto.IdUsuarioRegistro = this.UserId();
                    dto.IdEstadoPedido = 1;

                    var result = await this._service.AgregarAsync(this.Mapper.Map<TPedido>(dto));
                    if (result)
                    {
                        var resultUnidad = await this._unidadService.ActualizarCantidadAsync(dto.IdUnidad, dto.Cantidad, false, this.UserId());
                        return RedirectToAction(nameof(Index), new { userId = this.UserId() });
                    }
                }

                return RedirectToAction(nameof(Index), new { userId = this.UserId() });
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }
    }
}