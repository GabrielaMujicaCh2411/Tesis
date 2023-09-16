using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Copreter.Domain.Service.Contracts.Interfaces;
using Copreter.Domain.Service.Dto.Factura;
using Copreter.Domain.Model.DbModel;
using Copreter.Utils;

namespace Copreter.Controllers
{
    public class Facturacontroller : BaseController
    {
        #region Fields

        private readonly ILogger<Facturacontroller> _logger;

        private readonly IFacturaService _service;


        #endregion

        public Facturacontroller(IMapper mapper, ILogger<Facturacontroller> logger, IWebHostEnvironment hosting,
            IFacturaService service) : base(mapper)
        {
            this._logger = logger;
            this._service = service;
            this._hosting = hosting;
        }

        public IActionResult Cargar(int idCotizacion)
        {
            var result = new FacturaDto
            {
                IdCotizacion = idCotizacion
            };
            return View(result);
        }


        public async Task<IActionResult> Enviar([Bind()] FacturaDto dto)
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

                var result = await this._service.AgregarAsync(this.Mapper.Map<TFactura>(dto));
                if (result)
                {
                    return RedirectToAction(nameof(Index), Keys.ControllerKeys.Cotizacion);
                }
                return RedirectToAction(nameof(Index), Keys.ControllerKeys.Cotizacion);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message);
                return View();
            }
        }
    }
}