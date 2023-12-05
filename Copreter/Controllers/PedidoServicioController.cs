using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.PedidoOrdenServicio;
using Copreter.Models.PedidoOrdenServicio;
using Copreter.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class PedidoServicioController : BaseController
    {
        #region Fields

        private readonly ILogger<PedidoServicioController> _logger;

        private readonly IPedidoOrdenServicioService _service;

        private readonly IObraService _obraservice;

        private readonly ICotizacionService _cotizacionService;

        private readonly IPagoService _pagoService;

        #endregion

        public PedidoServicioController(IMapper mapper, ILogger<PedidoServicioController> logger, IWebHostEnvironment hosting,
            IPedidoOrdenServicioService service, IObraService obraservice, ICotizacionService cotizacionService, IPagoService pagoService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._hosting = hosting;

            this._obraservice = obraservice;
            this._cotizacionService = cotizacionService;
            this._pagoService = pagoService;
        }

        public async Task<IActionResult> Index(int idPedido)
        {
            var resultService = await this._service.ObtenerPorIdPedidoAsync(idPedido);

            var result = new PedidoOrdenServicioVM
            {
                DtoList = this.Mapper.Map<IEnumerable<PedidoOrdenServicioDto>>(resultService),
            };
            return View(result);
        }

        public IActionResult Cargar(int idPedido)
        {
            var result = new PedidoOrdenServicioDto
            {
                IdPedido = idPedido
            };
            return View(result);
        }

        public async Task<IActionResult> Enviar([Bind()] PedidoOrdenServicioDto dto)
        {
            try
            {
                if (dto.Foto != null)
                {
                    string ficherosImagenes = Path.Combine(this._hosting.WebRootPath, "images");
                    var guidImage = Guid.NewGuid().ToString() + dto.Foto.FileName;
                    string rutaDefinitiva = Path.Combine(ficherosImagenes, guidImage);
                    dto.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
                    dto.Imagen = guidImage;
                }

                dto.IdUsuarioRegistro = this.UserId();

                var result = await this._service.AgregarAsync(this.Mapper.Map<TPedidoOrdenServicio>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index), Keys.ControllerKeys.Pedido);
                }
                return RedirectToAction(nameof(Index), Keys.ControllerKeys.Pedido);
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

            var result = this.Mapper.Map<PedidoOrdenServicioDto>(resultService);
            return View(result);
        }
    }
}
