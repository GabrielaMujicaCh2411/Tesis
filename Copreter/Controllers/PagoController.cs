using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Model.Enums;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Pago;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class PagoController : BaseController
    {
        #region Fields

        private readonly ILogger<PagoController> _logger;

        private readonly IPagoService _service;

        private readonly ICotizacionService _cotizacionService;

        #endregion


        public PagoController(IMapper mapper, ILogger<PagoController> logger, IPagoService service, ICotizacionService cotizacionService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;

            this._cotizacionService = cotizacionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Crear(int idCotizacion)
        {
            try
            {
                var cotizacion = await this._cotizacionService.ObtenerAsync(idCotizacion);

                var result = new PagoDto
                {
                    IdCotizacion = idCotizacion,
                    Fecha = DateTime.Now
                };

                var factura = await this._service.ObtenerPoIdCotizacionAsync(idCotizacion);
                if (factura != null)
                {
                    result.Monto = factura.Saldo;
                    result.Saldo = 0;
                }
                else
                {
                    result.Monto = cotizacion.Total / 2;
                    result.Saldo = cotizacion.Total - result.Monto;
                }

                return View(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        // POST: Pago/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind()] PagoDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dto);
                }

                var cotizacion = await this._cotizacionService.ObtenerAsync(dto.IdCotizacion);
                if (cotizacion == null) return Redirect("/Home/IndexAdmin");

                var result = await this._service.AgregarAsync(this.Mapper.Map<TPago>(dto));
                if (result)
                {
                    await this._cotizacionService.ActualizarEstadoAsync(dto.IdCotizacion, (int)ECotizacionEstado.Segundofacturado, this.UserId());
                    return Redirect("/Home/IndexAdmin");
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}