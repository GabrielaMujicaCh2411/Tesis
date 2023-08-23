using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto;
using Copreter.Domain.Service.Dto.Pedido;
using Copreter.Models.Pedido;
using Copreter.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class PedidoController : BaseController
    {
        #region Fields

        private readonly IPedidoService _service;
        private readonly ITrabajadorService _trabajadorService;

        #endregion

        public PedidoController(IMapper mapper, IPedidoService service, ITrabajadorService trabajadorService) : base(mapper)
        {
            this._service = service;
            this._trabajadorService = trabajadorService;
        }

        public async Task<IActionResult> Index(int idestado)
        {
            var resultService = await this._service.ListarAsync();

            var result = new PedidoIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PedidoDto>>(resultService)
            };
            return View(result);
        }

        public async Task<IActionResult> _Index(int idestado)
        {
            var resultService = await this._service.ListarAsync();

            var result = new PedidoIndexVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PedidoDto>>(resultService)
            };
            return PartialView(result);
        }

        public async Task<IActionResult> Asignar(int id)
        {
            var resultService = await this._service.ObtenerAsync(id);
            if (resultService == null) return RedirectToAction(nameof(Index));

            var trabajadorLista = this.Mapper.Map<IEnumerable<ItemDto>>(await this._trabajadorService.ListarAsync());

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

                if (ModelState.IsValid)
                {
                    dto.IdEstadoPedido = 3;
                    var result = await this._service.ActualizarAsync(id, this.Mapper.Map<TPedido>(dto));
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

        public async Task<IActionResult> Rechazar(int id)
        {
            var resultService = await this._service.ObtenerAsync(id);
            if (resultService == null) return RedirectToAction(nameof(Index));

            resultService.IdEstadoPedido = 6;

            var result = await this._service.ActualizarAsync(id, resultService);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }
    }
}