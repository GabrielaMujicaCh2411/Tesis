using AutoMapper;
using Copreter.Domain.Model.DbModel;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Adenda;
using Copreter.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Copreter.Controllers
{
    public class AdendaController : BaseController
    {
        #region Fields

        private readonly ILogger<OrdenServicioController> _logger;

        private readonly IAdendaService _service;

        private readonly IObraService _obraservice;

        private readonly ICotizacionService _cotizacionService;

        private readonly IPagoService _pagoService;

        #endregion

        public AdendaController(IMapper mapper, ILogger<OrdenServicioController> logger, IWebHostEnvironment hosting,
            IAdendaService service, IObraService obraservice, ICotizacionService cotizacionService, IPagoService pagoService) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._hosting = hosting;

            this._obraservice = obraservice;
            this._cotizacionService = cotizacionService;
            this._pagoService = pagoService;
        }

        public IActionResult Cargar(int idPedido)
        {
            var result = new AdendaDto
            {
                IdPedido = idPedido,
            };
            return View(result);
        }

        public async Task<IActionResult> Enviar([Bind()] AdendaDto dto)
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

                var result = await this._service.AgregarAsync(this.Mapper.Map<TAdenda>(dto));

                return RedirectToAction(nameof(Index), Keys.ControllerKeys.Pedido);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }
    }
}
